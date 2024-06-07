using WebApplication3.Models;

namespace WebApplication3.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Patients.Any())
        {
            return;
        }

        var patients = new Patient[]
        {
            new Patient { FirstName = "Jan", LastName = "Kowalski", DateOfBirth = new DateTime(1980, 1, 1) },
            new Patient { FirstName = "Anna", LastName = "Nowak", DateOfBirth = new DateTime(1990, 2, 2) }
        };

        foreach (Patient p in patients)
        {
            context.Patients.Add(p);
        }

        var doctors = new Doctor[]
        {
            new Doctor { FirstName = "Piotr", LastName = "Lekarz", Specialty = "Kardiolog" },
            new Doctor { FirstName = "Maria", LastName = "Doktor", Specialty = "Neurolog" }
        };

        foreach (Doctor d in doctors)
        {
            context.Doctors.Add(d);
        }

        var medications = new Medication[]
        {
            new Medication { Name = "Paracetamol", Description = "Lek przeciwbólowy" },
            new Medication { Name = "Ibuprofen", Description = "Lek przeciwzapalny" }
        };

        foreach (Medication m in medications)
        {
            context.Medications.Add(m);
        }

        var prescriptions = new Prescription[]
        {
            new Prescription
            {
                Patient = patients[0],
                Doctor = doctors[0],
                Date = new DateTime(2023, 6, 1),
                DueDate = new DateTime(2023, 7, 1),
                PrescriptionMedications = new List<PrescriptionMedication>
                {
                    new PrescriptionMedication { Medication = medications[0], Dose = 1 },
                    new PrescriptionMedication { Medication = medications[1], Dose = 2 }
                }
            },
            new Prescription
            {
                Patient = patients[1],
                Doctor = doctors[1],
                Date = new DateTime(2023, 5, 15),
                DueDate = new DateTime(2023, 6, 15),
                PrescriptionMedications = new List<PrescriptionMedication>
                {
                    new PrescriptionMedication { Medication = medications[1], Dose = 3 }
                }
            }
        };

        foreach (Prescription pr in prescriptions)
        {
            context.Prescriptions.Add(pr);
        }

        context.SaveChanges();
    }
}
