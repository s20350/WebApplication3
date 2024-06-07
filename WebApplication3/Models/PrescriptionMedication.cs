namespace WebApplication3.Models;

public class PrescriptionMedication
{
    public int Id { get; set; }
    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }
    public int MedicationId { get; set; }
    public Medication Medication { get; set; }
    public int Dose { get; set; }
}
