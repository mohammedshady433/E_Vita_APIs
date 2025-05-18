using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs
{
    public class DBcontext : DbContext
    {
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<Operation_Room> Operation_Rooms { get; set; }
        public DbSet<Quantity> Quantities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<FamHistory> FamHistories { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Observation_Vital> observation_Vitals { get; set; }
        public DbSet<SharedNote> SharedNotes { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Scheduale> scheduales { get; set; }
        public DbSet<Discharge> Discharges { get; set; }
        public DbSet<WardRound> WardRounds { get; set; }
        public DbSet<Contact_fam> Contact_Fams { get; set; }
        public DbSet<Models.Results> Result { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Radiology> Radiologies { get; set; }
        public DbSet<Practitioner_Role> Practitioners_Role { get; set; }
        public DbSet<AppointmentPractitioner> AppointmentPractitioners { get; set; }

        public DBcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Contact_fam>()
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<Discharge>()
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<Operation_Room>()
                .HasKey(p => p.RoomId);

            modelBuilder.Entity<Practitioner_Role>()
                .HasKey(p => p.PractitionerId);

            modelBuilder.Entity<Quantity>()
                .HasKey(p => p.Observation_VitalsId);

            modelBuilder.Entity<Models.Results>()
                .HasKey(p => p.LabId);

            modelBuilder.Entity<Models.Results>()
                .HasKey(r => r.ResultId);

            modelBuilder.Entity<Models.Results>()
                .HasOne(r => r.Lab)
                .WithMany(l => l.Results)
                .HasForeignKey(r => r.LabId);

            modelBuilder.Entity<Models.Results>()
                .HasOne(r => r.Patient)
                .WithMany(p => p.Results)
                .HasForeignKey(r => r.PatientId);

            modelBuilder.Entity<AppointmentPractitioner>()
            .HasKey(ap => new { ap.AppointmentId, ap.PractitionersId });

            modelBuilder.Entity<AppointmentPractitioner>()
                .HasOne(ap => ap.Appointment)
                .WithMany(a => a.AppointmentPractitioners)
                .HasForeignKey(ap => ap.AppointmentId);

            modelBuilder.Entity<AppointmentPractitioner>()
                .HasOne(ap => ap.Practitioner)
                .WithMany(p => p.AppointmentPractitioners)
                .HasForeignKey(ap => ap.PractitionersId);

            base.OnModelCreating(modelBuilder); // Call the base method to ensure any additional configurations are applied
        }


    }
}
