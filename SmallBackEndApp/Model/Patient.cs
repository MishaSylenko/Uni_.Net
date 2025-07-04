using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Patient
{
    [Key] 
    public int IdPatient { get; set; }
    
    [Required] 
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required] 
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required] 
    [MaxLength(100)]
    public DateTime Birthdate { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; }
}

