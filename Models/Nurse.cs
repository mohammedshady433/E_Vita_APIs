using System.ComponentModel.DataAnnotations;

namespace E_Vita_APIs.Models
{
    public class Nurse
    {
        [Key]
        public string Nurse_ID { get; set; }
        public decimal Salary { get; set; }
        public string Rank { get; set; }
        public string Speciality { get; set; }
    }
} 