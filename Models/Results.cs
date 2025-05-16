using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class Results
    {
        public string Range { get; set; }
        public DateTime Date { get; set; }
        public string TestComponent { get; set; }
        [ForeignKey("Lab")]
        public int LabId { get; set; } // Foreign key to the Lab table
        [ForeignKey("Patient")]
        public int PatientId { get; set; } // Foreign key to the Patient table

    }
}
