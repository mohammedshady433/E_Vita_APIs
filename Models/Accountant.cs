using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class Accountant
    {
        [Key]
        public string Accountant_ID { get; set; }
        public decimal Salary { get; set; }
        public DateTime Shift { get; set; }
        public string Finance_ID { get; set; } // FK property

        [ForeignKey("Finance_ID")]
        public Finance finance { get; set; } // Navigation property

    }
}
