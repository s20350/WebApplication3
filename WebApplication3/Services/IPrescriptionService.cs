using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IPrescriptionService
{
    Task AddPrescriptionAsync(Prescription prescription);
}
