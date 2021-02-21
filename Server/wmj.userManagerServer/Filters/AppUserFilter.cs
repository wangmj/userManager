using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Filters;

using wmj.userManagerServer.Domain.Models;
using wmj.userManagerServer.Infra;

namespace wmj.userManagerServer.Filters
{
    public class AppUserFilter : IAsyncActionFilter
    {
        private SessionUser user;

        public AppUserFilter(SessionUser user)
        {
            this.user = user;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var contextUser= context.HttpContext.User;
            if (contextUser != null)
            {
                user=new SessionUser();
                user.Id=contextUser.Get<int>(ClaimTypes.Uri);
                user.Name=contextUser.Get<string>(ClaimTypes.NameIdentifier);
            }
            else
            {
                user=null;
            }
            await next();
        }
    }
}
