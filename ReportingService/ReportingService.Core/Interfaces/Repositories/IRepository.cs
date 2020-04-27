﻿using ReportingService.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Core.Interfaces.Repositories
{
    public interface IRepository
    {
        Task AddPostCode(PostCodeDTO postCodeDTO);
        Task AddAddress(AddressDetailsDTO addressDetailsDTO);
    }
}
