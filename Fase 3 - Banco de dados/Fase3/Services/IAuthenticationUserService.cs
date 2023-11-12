namespace Fase3.Services
{
    public interface IAuthenticationUserService
    {
        public Boolean authenticating(string? userName, string? password);

        public void saveAuthentication(HttpContext context, string userName, string password);

        public void clearAuthentication(HttpContext context);

    }
}
