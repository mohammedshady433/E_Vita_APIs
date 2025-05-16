using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class Encounter
    {
        public int Id { get; set; }
        public DateTime time { get; set; }
        public OUTIN_Patient type { get; set; } // OUTIN_Patient enum
        public string Reason { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; } // Foreign key to the Patient table
        [ForeignKey("Practitioner")]
        public int PractionerID { get; set; } 

    }

}
