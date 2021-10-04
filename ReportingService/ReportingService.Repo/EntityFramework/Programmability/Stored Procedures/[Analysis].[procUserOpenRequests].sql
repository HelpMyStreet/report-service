CREATE PROCEDURE [Analysis].[procUserOpenRequests]

AS

--Code to show what tasks a user should see in their open requests tab

--NOTE: Should check NATIONAL TASK LIST (in code near bottom - commented) periodically and update if new natioanl tasks have been added

--Ensure temp tables ar clear
IF OBJECT_ID('Analysis.UserOpenRequests', 'U') IS NOT NULL DROP TABLE Analysis.UserOpenRequests;
IF OBJECT_ID('tempdb.dbo.#UserSupport', 'U') IS NOT NULL DROP TABLE #UserSupport;
IF OBJECT_ID('tempdb.dbo.#UserSCPCs', 'U') IS NOT NULL DROP TABLE #UserSCPCs;
IF OBJECT_ID('tempdb.dbo.#OpenJobs', 'U') IS NOT NULL DROP TABLE #OpenJobs;
IF OBJECT_ID('tempdb.dbo.#InCriteriaJobs', 'U') IS NOT NULL DROP TABLE #InCriteriaJobs;
IF OBJECT_ID('tempdb.dbo.#ICJobsOrdered', 'U') IS NOT NULL DROP TABLE #ICJobsOrdered;
IF OBJECT_ID('tempdb.dbo.#Other20miles', 'U') IS NOT NULL DROP TABLE #Other20miles;
IF OBJECT_ID('tempdb.dbo.#OtherNational', 'U') IS NOT NULL DROP TABLE #OtherNational;
IF OBJECT_ID('tempdb.dbo.#OtherJobs', 'U') IS NOT NULL DROP TABLE #OtherJobs;
IF OBJECT_ID('tempdb.dbo.#OtherJobsOrdered', 'U') IS NOT NULL DROP TABLE #OtherJobsOrdered;

--Select user's location, verified status, support activities and group memberships (excluding test users)
select					a.ID as UserID
						,case
							when coalesce(a.IsVerified,0) = 1
								then 'Y'
							else 'N'
						end as Verified
						,a.PostalCode as User_Postcode
						,b.Coordinates
						,c.ActivityID
						,a.SupportRadiusMiles as Support_Radius
						,f.GroupID

into					#UserSupport
						
from					userlatest.[user] a

left join				Addresslatest.Postcode b
on						a.postalcode = b.postcode

left join				UserLatest.SupportActivity c
on						a.ID = c.UserID

left join				[Analysis].[UserFollowup] d
on						a.ID = d.UserID

left join				[UserLatest].[RegistrationHistory] e
on						a.ID = e.UserID
and						e.RegistrationStep = 4

left join				[GroupLatest].[UserRole] f
on						a.ID = f.UserID

where					coalesce(d.Test_Invalid,0) <> 1
and						e.UserID is not null;
--0s, 2946 rows 30/7
--1 row per user / group / support activity

--And their Championed postcodes (where relevant) (and group memberships again) - again, excluding test users
select					a.ID as UserID
						,case
							when coalesce(a.IsVerified,0) = 1
								then 'Y'
							else 'N'
						end as Verified
						,a.PostalCode as User_Postcode
						,c.Coordinates
						,b.PostalCode as SC_PostCode
						,f.GroupID
						
into					#UserSCPCs
						
from					userlatest.[user] a

left join				userlatest.ChampionPostcode b
on						a.id = b.UserID

left join				Addresslatest.Postcode c
on						a.postalcode = c.postcode

left join				[Analysis].[UserFollowup] d
on						a.ID = d.UserID

left join				[UserLatest].[RegistrationHistory] e
on						a.ID = e.UserID
and						e.RegistrationStep = 4

left join				[GroupLatest].[UserRole] f
on						a.ID = f.UserID

where					coalesce(d.Test_Invalid,0) <> 1
and						e.UserID is not null
and						coalesce(a.streetchampionroleunderstood,0) = 1;
--0s, 265 rows 30/7
--1 row per SC / group / supported postcode

--select all open jobs (with co-ordinates) (excluding those from test requests) - and the groups they're visible to
select					a.ID as JobID
						,b.postcode
						,c.Coordinates
						,a.SupportActivityID
						,cast(a.DueDate as Date) as DueDate
						,a.IsHealthCritical
						,e.GroupID

into					#OpenJobs
						
from					requestlatest.job a

left join				requestlatest.request b
on						a.requestid = b.ID

left join				addresslatest.postcode c
on						b.PostCode = c.Postcode

left join				analysis.testrequests d
on						b.id = d.requestid

left join				[RequestLatest].[JobAvailableToGroup] e
on						a.ID = e.JobID

where					a.jobstatusid = 1
and						d.requestid is null;
--0s, 15 rows 30/7
--1 row per open job / group

--select jobs to go in the top section (that are visible to volunteers them based on their group memberships, help types and radius)
--Note - these are only jobs that meet the volunteer's criteria and do NOT include (as I had first thought) jobs that are in Street Champs championed postcodes that don't meet their criteria
--But do flag jobs in SC postcodes
select					a.UserID
						,a.Verified
						,'In Criteria' as Section
						,'In Criteria' as Reason
						,case
							when d.UserID is not null
								then 'Y'
							else 'N'
						end as Championed_Postcode
						,c.ShortName as Activity_Type
						,b.PostCode as Postcode
						,round(a.Coordinates.STDistance(b.[Coordinates])/1609.34,1) as Miles_Away
						,b.DueDate as Due_Date
						,b.IsHealthCritical as Critical
						,b.JobID

into					#InCriteriaJobs
						
from					#UserSupport a

inner join				#OpenJobs b
on						a.activityID = b.SupportActivityID
and						a.Coordinates.STDistance(b.[Coordinates])/1609.34 <= a.Support_Radius
and						a.GroupID = b.GroupID

left join				analysis.ActivityLookup c
on						b.SupportActivityID = c.ActivityID

left join				#UserSCPCs d
on						b.PostCode = d.SC_PostCode
and						b.GroupID = d.GroupID

group by				a.UserID
						,a.Verified
						,case
							when d.UserID is not null
								then 'Y'
							else 'N'
						end
						,c.ShortName 
						,b.PostCode 
						,round(a.Coordinates.STDistance(b.[Coordinates])/1609.34,1) 
						,b.DueDate 
						,b.IsHealthCritical 
						,b.JobID;
--1s, 17 rows 30/7
--1 row per user / supported job (excluding those they're SC for and those not visible to them due to the group memberships they hold)

--Then all other jobs within 20 miles (visible by group membership)
select					a.UserID
						,a.Verified
						,'Other' as Section
						,'20 Miles' as Reason
						,case
							when e.UserID is not null
								then 'Y'
							else 'N'
						end as Championed_Postcode
						,c.ShortName as Activity_Type
						,b.PostCode as Postcode
						,round(a.Coordinates.STDistance(b.[Coordinates])/1609.34,1) as Miles_Away
						,b.DueDate as Due_Date
						,b.IsHealthCritical as Critical
						,b.JobID

into					#Other20miles
						
from					#UserSupport a

inner join				#OpenJobs b
on						a.Coordinates.STDistance(b.[Coordinates])/1609.34 < 20
and						a.GroupID = b.groupid

left join				analysis.ActivityLookup c
on						b.SupportActivityID = c.ActivityID

left join				#InCriteriaJobs d
on						b.jobID = d.JobID
and						a.UserID = d.UserID

left join				#UserSCPCs e
on						b.PostCode = e.SC_PostCode
and						b.GroupID = e.GroupID	

where					d.JobID is null

group by				a.UserID
						,a.Verified
						,case
							when e.UserID is not null
								then 'Y'
							else 'N'
						end
						,c.ShortName 
						,b.PostCode 
						,round(a.Coordinates.STDistance(b.[Coordinates])/1609.34,1) 
						,b.DueDate 
						,b.IsHealthCritical
						,b.JobID;
--0s, 281 rows 30/7 (down from >600 ?)

--Then all other jobs of national types that the user signed up to (visible by group membership)
select					a.UserID
						,a.Verified
						,'Other' as Section
						,'National' as Reason
						,'N' as Championed_Postcode
						,c.ShortName as Activity_Type
						,b.PostCode as Postcode
						,round(a.Coordinates.STDistance(b.[Coordinates])/1609.34,1) as Miles_Away
						,b.DueDate as Due_Date
						,b.IsHealthCritical as Critical
						,b.JobID

into					#OtherNational
						
from					#UserSupport a

inner join				#OpenJobs b
on						a.ActivityID = b.SupportActivityID
and						a.GroupID = b.groupid

left join				analysis.ActivityLookup c
on						b.SupportActivityID = c.ActivityID

left join				#Other20miles d
on						b.jobID = d.JobID
and						a.UserID = d.UserID

left join				#InCriteriaJobs e
on						b.jobID = e.JobID
and						a.UserID = e.UserID

where					a.ActivityID in (7,8,9,12) --(Friendly chat, supportive chat, home schooling and face coverings, respectively)
and						d.JobID is null
and						e.JobID is null

group by				a.UserID
						,a.Verified
						,c.ShortName 
						,b.PostCode 
						,round(a.Coordinates.STDistance(b.[Coordinates])/1609.34,1) 
						,b.DueDate 
						,b.IsHealthCritical 
						,b.JobID;
--0s, 3,527 rows 30/7

--Merge 'Other' Jobs
select *
into					#OtherJobs
from					#other20miles 
union all
select *
from					#othernational;
--0s, 3, 718 rows 30 / 7

--Order the 'In Criteria' jobs(for each user)
				select UserID
										, Verified
										, Section
										, Reason
										, Championed_Postcode
										, row_number()
							over
								(
								partition by
									UserID
								order by
									Due_date
									, Critical desc
									, Miles_Away
								) as Position_In_Section
						,Activity_Type
						,Due_Date as Due
						,Postcode
						,Miles_Away
						,Critical
						,JobID

into					#ICJobsOrdered
						
from					#InCriteriaJobs;
--0s, 15 rows 30 / 7

--Order the Other jobs
select UserID
						, Verified
						, Section
						, Reason
						, Championed_Postcode
						, row_number()
							over
								(
								partition by
									UserID
								order by
									Due_date
									, Critical desc
									, Miles_Away
								) as Position_In_Section
						,Activity_Type
						,Due_Date as Due
						,Postcode
						,Miles_Away
						,Critical
						,JobID

into					#OtherJobsOrdered

from					#otherjobs;
-- 0s, 3,718 rows 30 / 7

select*
into                    Analysis.UserOpenRequests
from					#ICJobsOrdered
union all
select*
from					#OtherJobsOrdered
where Position_In_Section <= 20;
			--0s, 3,401 rows 30 / 7

			--Clean up temp tables
IF OBJECT_ID('tempdb.dbo.#UserSupport', 'U') IS NOT NULL DROP TABLE #UserSupport;
IF OBJECT_ID('tempdb.dbo.#UserSCPCs', 'U') IS NOT NULL DROP TABLE #UserSCPCs;
IF OBJECT_ID('tempdb.dbo.#OpenJobs', 'U') IS NOT NULL DROP TABLE #OpenJobs;
IF OBJECT_ID('tempdb.dbo.#InCriteriaJobs', 'U') IS NOT NULL DROP TABLE #InCriteriaJobs;
IF OBJECT_ID('tempdb.dbo.#ICJobsOrdered', 'U') IS NOT NULL DROP TABLE #ICJobsOrdered;
IF OBJECT_ID('tempdb.dbo.#Other20miles', 'U') IS NOT NULL DROP TABLE #Other20miles;
IF OBJECT_ID('tempdb.dbo.#OtherNational', 'U') IS NOT NULL DROP TABLE #OtherNational;
IF OBJECT_ID('tempdb.dbo.#OtherJobs', 'U') IS NOT NULL DROP TABLE #OtherJobs;
IF OBJECT_ID('tempdb.dbo.#OtherJobsOrdered', 'U') IS NOT NULL DROP TABLE #OtherJobsOrdered