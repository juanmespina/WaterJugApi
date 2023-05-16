using Microsoft.AspNetCore.Mvc;
using WaterJugGame;

namespace WaterJugApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WaterJugGameController : ControllerBase
{
    [HttpPost("")]
    public IActionResult solveWaterJugGame([FromBody] WaterJugParams waterJugParams)
    {
        if ((waterJugParams.z > waterJugParams.x && waterJugParams.z > waterJugParams.y)
        || (waterJugParams.z < waterJugParams.x && waterJugParams.z < waterJugParams.y)
        || (waterJugParams.x <= 0 || waterJugParams.y <= 0 || waterJugParams.z <= 0))
        {
            return BadRequest("Not solution");
        }

        WaterJug smallerJug;
        WaterJug biggerJug;

        if (waterJugParams.x <= waterJugParams.y)
        {
            smallerJug = new WaterJug(waterJugParams.x, "x");
            biggerJug = new WaterJug(waterJugParams.y, "y");
        }
        else
        {
            smallerJug = new WaterJug(waterJugParams.y, "y");
            biggerJug = new WaterJug(waterJugParams.x, "x");
        }

        if (waterJugParams.z % smallerJug.MaxQtyGallons != 0)
        {
            return BadRequest("Not solution");

        }

        List<WaterJugsState> jugStates = new List<WaterJugsState>();
        jugStates.Add(
            new WaterJugsState(smallerJug, biggerJug,
            "Inicial state")
            );

        while (true)
        {
            if (biggerJug.CurrentAmount == waterJugParams.z
            || smallerJug.CurrentAmount == waterJugParams.z)
            {
                WaterJugsState lastState = jugStates[jugStates.Count - 1];
                lastState.Explanation = lastState.Explanation + ". Solved";
                jugStates[jugStates.Count - 1] = lastState;
                jugStates.RemoveAt(0);
                break;
            }
            //Fill a bucket
            if (smallerJug.CurrentAmount == 0)
            {
                smallerJug.CurrentAmount = smallerJug.MaxQtyGallons;
                jugStates.Add(
                 new WaterJugsState(smallerJug, biggerJug,
                $"Fill bucket {smallerJug.Name}"));
                continue;
            }

            //Transfer to bucket
            if ((smallerJug.CurrentAmount == smallerJug.MaxQtyGallons)
            && (biggerJug.CurrentAmount <= biggerJug.MaxQtyGallons)
            && (smallerJug.CurrentAmount + biggerJug.CurrentAmount <= biggerJug.MaxQtyGallons))
            {
                biggerJug.CurrentAmount = smallerJug.CurrentAmount + biggerJug.CurrentAmount;
                smallerJug.CurrentAmount = 0;
                jugStates.Add(
                 new WaterJugsState(smallerJug, biggerJug,
                $"Transfer bucket {smallerJug.Name} to bucket {biggerJug.Name}"));
                continue;
            }
        }
        return Ok(jugStates);
    }
}
