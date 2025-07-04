using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class AppUser
{
    [Key] 
    public int IdUser { get; set; }
    
    [Required] 
    public string Login { get; set; }
    
    [Required] 
    public string Password { get; set; }
    
    public string Salt { get; set; }
    
    public string RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExp { get; set; }
}