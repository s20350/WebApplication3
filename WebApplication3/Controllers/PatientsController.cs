using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;

    public PatientsController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        var patient = await _patientRepository.GetPatientAsync(id);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }
}
