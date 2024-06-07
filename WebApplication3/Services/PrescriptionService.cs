using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly ApplicationDbContext _context;

    public PrescriptionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddPrescriptionAsync(Prescription prescription)
    {
        if (prescription.Patient == null)
        {
            throw new ArgumentException("Pacjent nie istnieje.");
        }

        if (prescription.Doctor == null)
        {
            throw new ArgumentException("Lekarz nie istnieje.");
        }

        if (prescription.PrescriptionMedications.Count > 10)
        {
            throw new ArgumentException("Recepta może zawierać maksymalnie 10 leków.");
        }

        if (prescription.DueDate < prescription.Date)
        {
            throw new ArgumentException("Data ważności musi być większa lub równa dacie wystawienia.");
        }

        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }
}
