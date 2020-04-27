using AutoMapper;
using ReportingService.Core.Dto;
using ReportingService.Repo.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService.Mappers
{
    public class AddressDetailsProfile : Profile
    {
        public AddressDetailsProfile()
        {
            CreateMap<AddressDetails, AddressDetailsDTO>();
            CreateMap<AddressDetailsDTO, AddressDetails>();
        }
    }
}
