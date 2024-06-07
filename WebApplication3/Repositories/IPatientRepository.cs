using WebApplication3.Models;

namespace WebApplication3.Repositories;

public interface IPatientRepository
{
    Task<Patient> GetPatientAsync(int id);
    Task AddPatientAsync(Patient patient);
    Task SaveChangesAsync();
}
