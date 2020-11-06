using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReportingService.Repo.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService.Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            SqlConnection conn = (SqlConnection)Database.GetDbConnection();
            conn.AddAzureToken();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
