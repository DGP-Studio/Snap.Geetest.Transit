using Microsoft.AspNetCore.Mvc;
using Snap.Geetest.Transit.Client.Damagou;

namespace Snap.Geetest.Transit.Controllers;

[ApiController]
[Route("[controller]")]
public class DamagoController : ControllerBase
{
    private readonly DamagouClient damagouClient;

    public DamagoController(DamagouClient damagouClient)
    {
        this.damagouClient = damagouClient;
    }

    [HttpGet("Verify")]
    public async Task<IActionResult> VerifyAsync([FromQuery] string gt, [FromQuery] string challenge)
    {
        if (await damagouClient.LoginAsync() is { Status: 0, Data: { } userKey })
        {
            if (await damagouClient.VerifyAsync(userKey, gt, challenge) is { Status:0, Data: not null } result)
            {
                string[] param = result.Data.Split('|', 2);
                VerificationResponse response = new()
                {
                    Code = result.Status,
                    Data = new()
                    {
                        Gt = gt,
                        Challenge = param[0],
                        Validate = param[1],
                    }
                };

                return new JsonResult(response);
            }
        }

        VerificationResponse bad = new()
        {
            Code = 114514,
        };

        return new JsonResult(bad);
    }
}