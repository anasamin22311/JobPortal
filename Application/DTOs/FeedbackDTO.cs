using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FeedbackDTO : BaseEntityDTO
    {
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Message { get; set; }
    }
}
