using Microsoft.AspNetCore.Mvc;

namespace app.Features.Subject;

[ApiController]
[Route("subject")]
public class SubjectsController
{
    private static List<SubjectModel> _mockDb = new List<SubjectModel>();

    [HttpPost]
    public SubjectResponse Add(SubjectRequest request)
    {
        var subject = new SubjectModel()
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Name = request.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = request.Grades
        };

        _mockDb.Add(subject);

        return new SubjectResponse()
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }
}