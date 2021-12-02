using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TopicsApi.Data;

namespace TopicsApi.Controllers;

public class TopicsController : ControllerBase
{

    public readonly TopicsDataContext _context;

    public TopicsController(TopicsDataContext context)
    {
        _context = context;
    }

    [HttpGet("/topics")]
    public async Task<IActionResult> Index()
    {
        var response = await _context.Topics!.ToListAsync();
        return Ok(new { Data = response });
    }

    [HttpPost("/topics")]
    public async Task<IActionResult> Add([FromBody]PostTopicRequest request)
    {
        if(ModelState.IsValid)
        {
            var topic = new Topic {  Description = request.Description };
            _context.Topics!.Add(topic);
            await _context.SaveChangesAsync();
            return Ok(topic);
        } else
        {
            return BadRequest(ModelState);
        }
    }



}

public record PostTopicRequest
{
    [Required]
    public string? Description { get; init; }
}
