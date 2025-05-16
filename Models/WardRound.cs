using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class WardRound
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly Time { get; set; } // Time of the ward round
        public string Note { get; set; } // Note from the ward round
        [ForeignKey("Practitioner")]
        public int PractitionerId { get; set; } // Foreign key to the Practitioner table
    }
}
