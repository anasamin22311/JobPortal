﻿using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmployerDTO : BaseEntityDTO
    {
        public string CompanyName { get; set; }
        public string Contact { get; set; }
    }
}
