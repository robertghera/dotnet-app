using app.Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Features.Assignments;

[ApiController]
[Route("assignments")]
public class AssignmentsController : ControllerBase
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>();
    private AppDbContext dbContext;

    public AssignmentsController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<AssignmentResponse> Add(AssignmentRequest request)
    {
        var assignment = new AssignmentModel //mapping
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline
        };

        var response = await dbContext.AddAsync(assignment);
        await dbContext.SaveChangesAsync();
        
        return new AssignmentResponse
        {
            Id = response.Entity.Id,
            Subject = response.Entity.Subject,
            Description = response.Entity.Description,
            Deadline = response.Entity.Deadline
        };
    }

    [HttpGet]
    public async Task<IEnumerable<AssignmentResponse>> Get()
    {
        var entities = await dbContext.Assignments.ToListAsync();
        return entities.Select(
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
    public async Task<ActionResult<AssignmentResponse>> Get([FromRoute] string id)
    {
        var entity = await dbContext.Assignments.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null) return NotFound("Assignment not found");

        return new AssignmentResponse
        {
            Id = entity.Id,
            Subject = entity.Subject,
            Description = entity.Description,
            Deadline = entity.Deadline
        };
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AssignmentResponse>> Delete([FromRoute] string id)
    {
        var entity = await dbContext.Assignments.FirstOrDefaultAsync(a => a.Id == id);
        if (entity is null) return NotFound("Assignment not found");

        dbContext.Assignments.Remove(entity);
        await dbContext.SaveChangesAsync();

        return new AssignmentResponse
        {
            Id = entity.Id,
            Subject = entity.Subject,
            Description = entity.Description,
            Deadline = entity.Deadline
        };
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<AssignmentResponse>> Update([FromRoute] string id,[FromBody] AssignmentRequest request)
    {   
        var entity = await dbContext.Assignments.FirstOrDefaultAsync(a => a.Id == id);
        if (entity is null) return null;

        entity.Updated = DateTime.UtcNow;
        entity.Subject = request.Subject;
        entity.Description = request.Description;
        entity.Deadline = request.Deadline;

        await dbContext.SaveChangesAsync();

        return new AssignmentResponse
        {
            Id = entity.Id,
            Subject = entity.Subject,
            Description = entity.Description,
            Deadline = entity.Deadline
        };
    }
}