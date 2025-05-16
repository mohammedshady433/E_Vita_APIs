using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class FamHistory
    {
        public int ID { get; set; }
        public string Disease { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Practitioner")]
        public int PractionerID { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; } // Foreign key to the Patient table
    }
}
