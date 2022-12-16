using app.Features.Assignments.Models;
using app.Features.Assignments.Views;
using Microsoft.AspNetCore.Mvc;

namespace app.Features.Assignments;

[ApiController]
[Route("assignments")]
public class AssignmentsController
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>();

    [HttpPost]
    public AssignmentResponse Add(AssignmentRequest request)
    {
        var assignment = new AssignmentModel//mapping
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline
        };
        
        _mockDb.Add(assignment);

        return new AssignmentResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentResponse> Get()
    {
        return _mockDb.Select(
            assignment => new AssignmentResponse()
            {
                Id = assignment.Id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline      
            }
        ).ToList();
    }

    [HttpGet("{id}")]
    public AssignmentResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.Id == id);
        if (assignment is null)
        {
            return null;
        }
        
        return new AssignmentResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }
    //TODO HttpDeLETE, HttpPatch, delete dupa id si update cu return la obiect sub forma de AssignmentResponse
}