using System;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class Controller : ControllerBase
{
    //ez majd változik csak kezdteben ezt a nevet adtam neki
    [HttpGet("kezdo")]
    public IActionResult kezdo([FromQuery])
    {
        return Ok();
    }
}
