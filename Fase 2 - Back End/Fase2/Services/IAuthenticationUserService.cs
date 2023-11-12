namespace Fase2.Services
{
    public interface IAuthenticationUserService
    {
        public Boolean authenticating(string? userName, string? password);

        public void saveAuthentication(HttpContext context, string userName, string password);

        public void clearAuthentication(HttpContext context);

    }
}
