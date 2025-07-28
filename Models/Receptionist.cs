using System.ComponentModel.DataAnnotations;

namespace E_Vita_APIs.Models
{
    public class Receptionist
    {
        [Key]
        public string Receptionist_ID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Salary { get; set; }


    }
} 