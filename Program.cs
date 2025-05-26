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
builder.Services.AddScoped<IRepositories<Bed>, BedRepo>();
builder.Services.AddScoped<IRepositories<Contact_fam>, ContactFamRepo>();
builder.Services.AddScoped<IRepositories<Discharge>, DischargeRepo>();
builder.Services.AddScoped<IRepositories<Encounter>, EncounterRepo>();
builder.Services.AddScoped<IRepositories<FamHistory>, FamHistoryRepo>();
builder.Services.AddScoped<IRepositories<Financial>, FinancialRepo>();
builder.Services.AddScoped<IRepositories<Lab>, LabRepo>();
builder.Services.AddScoped<IRepositories<Medication>, MedicationRepo>();
builder.Services.AddScoped<IRepositories<Observation_Vital>, ObservationVitalRepo>();
builder.Services.AddScoped<IRepositories<Operation_Room>, OperationRoomRepo>();
builder.Services.AddScoped<IRepositories<Patient>, PatientRepo>();
builder.Services.AddScoped<IRepositories<Practitioner>, PractitionerRepo>();
builder.Services.AddScoped<IRepositories<Practitioner_Role>, PractitionerRoleRepo>();
builder.Services.AddScoped<IRepositories<Prescription>, PrescriptionRepo>();
builder.Services.AddScoped<IRepositories<Quantity>, QuantityRepo>();
builder.Services.AddScoped<IRepositories<Radiology>, RadiologyRepo>();
builder.Services.AddScoped<RadiologyRepo>();
builder.Services.AddScoped<IRepositories<E_Vita_APIs.Models.Results>, ResultsRepo>();
builder.Services.AddScoped<IRepositories<Room>, RoomRepo>();
builder.Services.AddScoped<IRepositories<Scheduale>, ScheduleRepo>();
builder.Services.AddScoped<IRepositories<SharedNote>, SharedNoteRepo>();
builder.Services.AddScoped<IRepositories<WardRound>, WardRoundRepo>();
builder.Services.AddScoped<IRepositories<AppointmentPractitioner>, AppointmentPractitionerRepo>();
// ------------------------------------------------------------------------
builder.Services.AddScoped<AppointmentPractitionerRepo>();
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
