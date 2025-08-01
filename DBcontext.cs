﻿using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs
{
    public class DBcontext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Assigned> Assigneds { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Beds> Beds { get; set; }
        public DbSet<FamilyHistory> FamilyHistories { get; set; }
        public DbSet<Schedule> scheduales { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<Accountant> Accountants { get; set; }
        public DbSet<Lab_technician> Lab_Technicians { get; set; }
        public DbSet<Rad_technician> Rad_Technicians { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<SharedNote> SharedNotes { get; set; }
        public DbSet<WardRound> WardRounds { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Radiology> Radiologies { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<PatientHistory> patientHistories { get; set; }
        public DbSet<PatientCareEquipment> PatientCareEquipments { get; set; }
        public DBcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assigned>().HasKey(a => new { a.NurseID, a.RoomID });
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    modelBuilder.Entity<Contact_fam>()
        //        .HasKey(p => p.PatientId);

        //    modelBuilder.Entity<Discharge>()
        //        .HasKey(p => p.PatientId);

        //    modelBuilder.Entity<Operation_Room>()
        //        .HasKey(p => p.RoomId);

        //    modelBuilder.Entity<Practitioner_Role>()
        //        .HasKey(p => p.PractitionerId);

        //    modelBuilder.Entity<Quantity>()
        //        .HasKey(p => p.Observation_VitalsId);

        //    modelBuilder.Entity<Models.Results>()
        //        .HasKey(p => p.LabId);

        //    modelBuilder.Entity<Models.Results>()
        //        .HasKey(r => r.ResultId);

        //    modelBuilder.Entity<Models.Results>()
        //        .HasOne(r => r.Lab)
        //        .WithMany(l => l.Results)
        //        .HasForeignKey(r => r.LabId);

        //    modelBuilder.Entity<Models.Results>()
        //        .HasOne(r => r.Patient)
        //        .WithMany(p => p.Results)
        //        .HasForeignKey(r => r.PatientId);

        //    modelBuilder.Entity<AppointmentPractitioner>()
        //    .HasKey(ap => new { ap.AppointmentId, ap.PractitionersId });

        //    modelBuilder.Entity<AppointmentPractitioner>()
        //        .HasOne(ap => ap.Appointment)
        //        .WithMany(a => a.AppointmentPractitioners)
        //        .HasForeignKey(ap => ap.AppointmentId);

        //    modelBuilder.Entity<AppointmentPractitioner>()
        //        .HasOne(ap => ap.Practitioner)
        //        .WithMany(p => p.AppointmentPractitioners)
        //        .HasForeignKey(ap => ap.PractitionersId);
        //    modelBuilder.Entity<Medication>()
        //        .HasOne(m => m.Prescription)
        //        .WithMany(p => p.Medications)
        //        .HasForeignKey(m => m.PrescriptionId);

        //    base.OnModelCreating(modelBuilder); // Call the base method to ensure any additional configurations are applied
        //}


    }
}
