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
    
    [HttpGet]
    public IEnumerable<SubjectResponse> Get()
    {
        return _mockDb.Select(
            subject => new SubjectResponse()
            {
                Id = subject.Id,
                Name = subject.Name,
                ProfessorMail = subject.ProfessorMail,
                Grades = subject.Grades
            }
        ).ToList();
    }
    
    [HttpGet("{id}")]
    public SubjectResponse Get([FromRoute] string id)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);
        if (subject is null) return null;

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }
    
    [HttpDelete("{id}")]
    public SubjectResponse Delete([FromRoute] string id)
    {
        var subject = _mockDb.FirstOrDefault(a => a.Id == id);
        if (subject is null) return null;

        _mockDb.Remove(subject);

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }
    
    [HttpPatch("{id}")]
    public SubjectResponse Update([FromRoute] string id,[FromBody] SubjectRequest request)
    {
        var subject = _mockDb.FirstOrDefault(user => user.Id == id);
        if (subject is null) return null;

        subject.Updated = DateTime.UtcNow;
        subject.Name = request.Name;
        subject.ProfessorMail = request.ProfessorMail;
        subject.Grades = request.Grades;

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }
}