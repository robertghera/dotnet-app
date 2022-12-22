namespace app.Features.Subject;

public class SubjectResponse
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string ProfessorMail { get; set; }

    public List<Double> Grades { get; set; }
}