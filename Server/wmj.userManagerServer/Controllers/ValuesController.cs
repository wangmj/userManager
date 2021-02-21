using Microsoft.AspNetCore.Mvc;

namespace wmj.userManagerServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public string Get()
        {
            return "success";
        }
    }
}
