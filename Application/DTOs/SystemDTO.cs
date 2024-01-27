using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class systemDTO : BaseEntityDTO
    {
        public string ConfigurationSettings { get; set; }
        public string Logs { get; set; }
    }
}
