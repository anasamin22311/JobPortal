using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LocationDTO : BaseEntityDTO
    {
        public string LocationName { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
