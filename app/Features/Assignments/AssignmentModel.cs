using app.Base;

namespace app.Features.Assignments;

public class AssignmentModel : Model
{
    public string Subject { get; set; }

    public string Description { get; set; }

    public DateTime Deadline { get; set; }
}