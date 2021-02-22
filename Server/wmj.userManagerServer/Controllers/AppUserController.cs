using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using wmj.userManagerServer.Domain.Interfaces;
using wmj.userManagerServer.Domain.Models;
using wmj.userManagerServer.Domain.ViewModels;

namespace wmj.userManagerServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private IBaseServices<AppUser, int> _appUserServices;
        private ITokenServices _tokenServices;
        public AppUserController(IBaseServices<AppUser, int> appUserServices, ITokenServices tokenServices)
        {
            _appUserServices = appUserServices;
            _tokenServices = tokenServices;
        }
        [HttpPost]
        public IActionResult Logon([FromBody] AppUserLogon user)
        {
            ServicesResult result = new ServicesResult();
            var logonUser = _appUserServices.Get(x => (x.Name.Equals(user.Name) || x.Phone.Equals(user.Name)) && x.Pwd.Equals(user.Pwd)).FirstOrDefault();
            if (logonUser != null && logonUser.Id != 0)
            {
                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, logonUser.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, logonUser.Name.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Email, logonUser.Email.ToString()));

                string token = _tokenServices.GenerateToken(userClaims);
                result.Result = 200;
                result.Data = new { user = new { Id = logonUser.Id, Name = logonUser.Name }, token };
            }
            else
            {
                var count = _appUserServices.Get(x => x.Name.Equals(user.Name) || x.Phone.Equals(user.Name)).Count();
                if (count > 0)
                {
                    result.Result = 201;
                    result.Msg = "请输入正确的用户名密码";
                }
                else
                {
                    result.Result = 204;
                    result.Msg = "用户名不存在，请注册";
                }
            }
            return Ok(result);
        }
        public IActionResult AddUser([FromBody] AppUserAdd user)
        {
            return Ok();
            //this.TryValidateModel(user)
        }
    }
}

