namespace WebApplication3.Models;

public class Prescription
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}
