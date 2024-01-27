using Application.DTOs.Common;
using JobPortal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class NotificationDTO : BaseEntityDTO
    {
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
    }
}
