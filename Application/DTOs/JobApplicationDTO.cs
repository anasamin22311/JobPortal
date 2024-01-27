using Application.DTOs.Common;
using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class JobApplicationDTO : BaseEntityDTO
    {
        public int CandidateID { get; set; }
        public int JobID { get; set; }
        public string Resume { get; set; }
        public string CoverLetter { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
