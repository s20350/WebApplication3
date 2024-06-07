namespace WebApplication3.Models;

public class Medication
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }

}
