using Application.DTOs.Common;
using JobPortal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SkillDTO : BaseEntityDTO
    {
        public string SkillName { get; set; }
        public SkillLevelDTO SkillLevel { get; set; }
    }
}
