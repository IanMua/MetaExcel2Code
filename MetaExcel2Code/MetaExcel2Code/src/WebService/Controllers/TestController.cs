using Microsoft.AspNetCore.Mvc;

namespace MetaExcel2Code.Controllers;

[ApiController]
[Route("api/test")]
public class TestController: ControllerBase
{
    [HttpGet]
    public IActionResult GetTest()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast = Enumerable.Range(1, 5).Select(index => new
        {
            Date = DateTime.Now.AddDays(index).ToString("yyyy-MM-dd"),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();

        return Ok(forecast);
    }
}