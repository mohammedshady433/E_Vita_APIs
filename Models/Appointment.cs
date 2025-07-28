using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Vita_APIs.Models
{
    public class Appointment
    {
        public string Id { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Cancelation_Reason { get; set; }
        public DateTime? Cancelation_Date { get; set; }
        public ServiceType Service_Type { get; set; }
        public string PatientId { get; set; } // FK property

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; } // Navigation property
        public string DoctorId { get; set; } // FK property

        [ForeignKey("DoctorId")]
        public Doctor DoctorID { get; set; } // Navigation property
    }
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Cancelled,
        NoShow
    }
    public enum ServiceType
    {
        Surgery,
        Emergency_Operation,
        clincal
    }
}
