using E_Vita_APIs;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using Microsoft.Extensions.DependencyInjection;
using E_Vita_APIs.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Needed for minimal APIs
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositories<Appointment>, AppointmentRepo>();
builder.Services.AddScoped<IRepositories<Accountant>, AccountantRepo>();
builder.Services.AddScoped<IRepositories<Assigned>, AssignedRepo>();
builder.Services.AddScoped<IRepositories<Attendance>, AttendanceRepo>();
builder.Services.AddScoped<IRepositories<Beds>, BedRepo>();
builder.Services.AddScoped<IRepositories<Days>, DaysRepo>();
builder.Services.AddScoped<IRepositories<Doctor>, DoctorRepo>();
builder.Services.AddScoped<IRepositories<FamilyHistory>, FamHistoryRepo>();
builder.Services.AddScoped<IRepositories<Finance>, FinanceRepo>();
builder.Services.AddScoped<IRepositories<Lab>, LabRepo>();
builder.Services.AddScoped<IRepositories<Lab_technician>, LabTechnicianRepo>();
builder.Services.AddScoped<IRepositories<Medication>, MedicationRepo>();
builder.Services.AddScoped<IRepositories<Nurse>, NurseRepo>();
builder.Services.AddScoped<IRepositories<Patient>, PatientRepo>();
builder.Services.AddScoped<IRepositories<PatientCareEquipment>, PatientCareEquipmentRepo>();
builder.Services.AddScoped<IRepositories<PatientHistory>, PatientHistoryRepo>();
builder.Services.AddScoped<IRepositories<Prescription>, PrescriptionRepo>();
builder.Services.AddScoped<IRepositories<Rad_technician>, RadTechnicianRepo>();
builder.Services.AddScoped<IRepositories<Radiology>, RadiologyRepo>();
builder.Services.AddScoped<IRepositories<Receptionist>, ReceptionistRepo>();
builder.Services.AddScoped<IRepositories<Rooms>, RoomRepo>();
builder.Services.AddScoped<IRepositories<Schedule>, ScheduleRepo>();
builder.Services.AddScoped<IRepositories<ScreentimeArticle>, ScreentimeArticleRepository>();
builder.Services.AddScoped<IRepositories<Service>, ServiceRepository>();
builder.Services.AddScoped<IRepositories<Share>, ShareRepo>();
builder.Services.AddScoped<IRepositories<SharedNote>, SharedNoteRepository>();
builder.Services.AddScoped<IRepositories<User>, UserRepo>();
builder.Services.AddScoped<IRepositories<WardRound>, WardRoundRepo>();
// ------------------------------------------------------------------------
// Dependency Injection for DBcontext
builder.Services.AddDbContext<DBcontext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8,0,41))));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
