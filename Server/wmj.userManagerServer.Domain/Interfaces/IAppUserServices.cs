using wmj.userManagerServer.Domain.Models;
using wmj.userManagerServer.Domain.ViewModels;

namespace wmj.userManagerServer.Domain.Interfaces
{
    public interface IAppUserServices
    {
        ServicesResult Logon(AppUserLogon user);
    }
}
