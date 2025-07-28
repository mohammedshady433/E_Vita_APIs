using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace E_Vita_APIs.Models
{
    public class Share
    {
        public string DoctorId { get; set; } // FK property

        [ForeignKey("DoctorId")]
        public Doctor DoctorID { get; set; } // Navigation property

        public string NoteId { get; set; } // FK property

        [ForeignKey("NoteID")]
        public Note NoteID { get; set; } // Navigation property

        public string NurseId { get; set; } // FK property

        [ForeignKey("NurseID")]
        public Nurse NurseID { get; set; } // Navigation property

        public string ReceptionistId { get; set; } // FK property

        [ForeignKey("ReceptionistId")]
        public Receptionist ReceptionistID { get; set; } // Navigation property

    }
}
