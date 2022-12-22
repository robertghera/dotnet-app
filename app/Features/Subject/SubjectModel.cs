using app.Base;

namespace app.Features.Subject;

public class SubjectModel : Model
{
    public string Name { get; set; }

    public string ProfessorMail { get; set; }

    public List<Double> Grades { get; set; }
}