using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class Medication
    {
        public float Dose { get; set; }
        public string Unit { get; set; }
        public TimeOnly Time { get; set; }
        public string Medication_name { get; set; }
        [ForeignKey("Practitioner")]
        public int PractionerID { get; set; } // Foreign key to the Patient table
    }
}