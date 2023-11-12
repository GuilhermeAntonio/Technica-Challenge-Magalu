namespace Fase2.Services
{
    public class AuthenticationUserService :  IAuthenticationUserService
    {
        bool IAuthenticationUserService.authenticating(string? userName, string? password)
        {

            return userName == "magalu" && password == "m@galu123";
        }

        void IAuthenticationUserService.saveAuthentication(HttpContext context, string userName, string password)
        {
            context.Session.SetString("userName", userName);
            context.Session.SetString("password", password);

        }

        void  IAuthenticationUserService.clearAuthentication(HttpContext context)
        {
            context.Session.Remove("userName");
            context.Session.Remove("password");
        }

    }

}
