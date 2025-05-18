using E_Vita_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Vita_APIs.Repositories
{
    public class AppointmentRepo : IRepositories<Appointment>
    {
        private readonly DBcontext _context;
        public AppointmentRepo(DBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Appointment entity)
        {
            await _context.Appointments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Appointments
                    .Include(a => a.Patient)
                    .FirstOrDefaultAsync(a => a.Id == id); 
            }
            catch
            {
                return new Appointment();
            }
        }

        public async Task UpdateAsync(Appointment updatedAppointment, int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                throw new ArgumentException("Appointment not found");
            }

            appointment.Start = updatedAppointment.Start;
            appointment.End = updatedAppointment.End;
            appointment.Status = updatedAppointment.Status;
            appointment.Cancelation_Reason = updatedAppointment.Cancelation_Reason;
            appointment.Cancelation_Date = updatedAppointment.Cancelation_Date;
            appointment.Service_Type = updatedAppointment.Service_Type;
            appointment.Duration = updatedAppointment.Duration;
            appointment.Actor = updatedAppointment.Actor;
            appointment.PatientId = updatedAppointment.PatientId;

            await _context.SaveChangesAsync();
        }
    }
} 