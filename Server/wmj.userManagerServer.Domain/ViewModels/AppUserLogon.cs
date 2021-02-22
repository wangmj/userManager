using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace wmj.userManagerServer.Domain.ViewModels
{
    public class AppUserLogon
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
    }
    public class AppUserLogonValidator:AbstractValidator<AppUserLogon>
    {
        public AppUserLogonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("用户名不能为空");
        }
    }
}
