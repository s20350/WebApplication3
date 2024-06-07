using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Patient> GetPatientAsync(int id)
    {
        return await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedications)
            .ThenInclude(pm => pm.Medication)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddPatientAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
