
namespace WebApplication1.dtos;

public class AddPrescriptionRequest
{
    public int IdDoctor { get; set; }
    public PatientRequest Patient { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<PrescriptionMedicamentRequest> Medicaments { get; set; }
}

public class PatientRequest
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}

public class PrescriptionMedicamentRequest
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Details { get; set; }
}