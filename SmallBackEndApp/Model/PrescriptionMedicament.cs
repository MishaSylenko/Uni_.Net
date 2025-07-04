using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class PrescriptionMedicament
{
    [Key]
    public int IdPrescription { get; set; }
    [Key]
    public int IdMedicament { get; set; }
    
    public int Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
    
    public virtual Prescription Prescription { get; set; }
    
    public virtual Medicament Medicament { get; set; }
}