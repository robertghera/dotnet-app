using System.ComponentModel.DataAnnotations;

namespace app.Features.Test;

public class TestRequest
{
    [Required]
    public string Subject { get; set; }

    [Required]
    public DateTime TestDate { get; set; }
}