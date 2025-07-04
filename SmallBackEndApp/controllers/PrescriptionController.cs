using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.dtos;
using WebApplication1.Model;

namespace WebApplication1.controllers;

[ApiController]
[Route("api/prescriptions")]
public class PrescriptionController : ControllerBase
{
    private readonly MedicineDbContext _context;

    public PrescriptionController(MedicineDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] AddPrescriptionRequest request)
    {
        if (request.Medicaments.Count > 10)
        {
            return BadRequest("Cannot add more than 10 medicaments to a prescription");
        }

        if (request.Date > request.DueDate)
        {
            return BadRequest("Due date cannot be earlier than the date of prescription");
        }

        var doctor = await _context.Doctors.FindAsync(request.IdDoctor);
        if (doctor == null)
        {
            return BadRequest("Doctor does not exist.");
        }

        var patient = await _context.Patients.FindAsync(request.Patient.IdPatient);

        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                Birthdate = request.Patient.Birthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = request.IdDoctor,
            PrescriptionMedicaments = new List<PrescriptionMedicament>()
        };

        foreach (var medRequest in request.Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(medRequest.IdMedicament);
            if (medicament == null)
            {
                return BadRequest($"Medicament with Id {medRequest.IdMedicament} does not exist.");
            }

            prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = medRequest.IdMedicament,
                Dose = medRequest.Dose,
                Details = medRequest.Details
            });
        }

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return Ok("Prescription with id " + prescription.IdPrescription + " added successfully.");
    }
}