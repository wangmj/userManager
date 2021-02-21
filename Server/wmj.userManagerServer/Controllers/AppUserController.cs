using Microsoft.AspNetCore.Mvc;

using wmj.userManagerServer.ViewModel.Users;

namespace wmj.userManagerServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        public IActionResult Logon([FromBody]AppUserLogon user)
        {
            return null;
        }
    }
}
