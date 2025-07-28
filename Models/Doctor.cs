using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class Doctor
    {
        [Key]
        public string Doctor_ID { get; set; }
        public decimal Salary { get; set; }
        public string Rank { get; set; }
        public string Speciality { get; set; }
        public string ChatId { get; set; }

        [ForeignKey("ChatId")]
        public Chatbot chatbot { get; set; }


    }
} 