using Microsoft.AspNetCore.Mvc;

namespace WaterJugApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WaterJugController : ControllerBase
{
    [HttpGet(Name = "test")]
    public string Get()
    {
        return "test";
    }
}
