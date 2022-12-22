using System.ComponentModel.DataAnnotations;

namespace app.Features.Subject;

public class SubjectRequest
{   
    [Required]
    public string Name { get; set; }
    
    [Required][EmailAddress]
    public string ProfessorMail { get; set; }
    
    [Required]
    public List<Double> Grades { get; set; }
}