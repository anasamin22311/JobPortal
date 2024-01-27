using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class Notification:BaseEntity
    {
        [Required]
        public int SenderID { get; set; }

        [Required]
        public int ReceiverID { get; set; }
        public int SystemId { get; set; }


        [Required]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        [Required]
        public Status Status { get; set; }

        // Navigation properties
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public system system { get; set; }
    }
}