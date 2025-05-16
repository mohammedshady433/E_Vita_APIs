using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace E_Vita_APIs.Models
{
    public class Practitioner_Role
    {
        public DateOnly Period { get; set; }
        public string Code { get; set; }
        public MedicalSpecialty Specialty { get; set; }
        public Service Service { get; set; }
        public DateAndTime Availability { get; set; }
        [ForeignKey("Practitioner")]
        public int PractionerID { get; set; } 
    }
}

public enum Service
{
    DoctorIN,
    DoctorOUT,
    Nurse,
    Patient,
    Laboratory,
}
  
        public enum MedicalSpecialty
        {
            AllergyAndImmunology,
            Anesthesiology,
            Cardiology,
            ColonAndRectalSurgery,
            CriticalCareMedicine,
            Dermatology,
            EmergencyMedicine,
            EndocrinologyAndMetabolism,
            FamilyMedicine,
            Gastroenterology,
            GeneralSurgery,
            GeriatricMedicine,
            Hematology,
            HospiceAndPalliativeMedicine,
            InfectiousDisease,
            InternalMedicine,
            MedicalGeneticsAndGenomics,
            Nephrology,
            Neurology,
            Neurosurgery,
            NuclearMedicine,
            ObstetricsAndGynecology,
            Oncology,
            Ophthalmology,
            OrthopedicSurgery,
            Otolaryngology,
            Pathology,
            Pediatrics,
            PhysicalMedicineAndRehabilitation,
            PlasticSurgery,
            Podiatry,
            PreventiveMedicine,
            Psychiatry,
            Pulmonology,
            Radiology,
            Rheumatology,
            SleepMedicine,
            SportsMedicine,
            ThoracicSurgery,
            TransplantSurgery,
            Urology,
            VascularSurgery
        }
    


