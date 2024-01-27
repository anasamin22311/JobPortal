using Application.DTOs.Common;
using JobPortal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDTO : BaseEntityDTO
    {
        public RoleDTO Role { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public int? EmployerId { get; set; }
    }
}
