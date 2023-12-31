﻿using Fase_3.Data;

namespace Fase3.Services
{
    public class AuthenticationUserService : IAuthenticationUserService
    {

        private readonly ApplicationDbcontext _context;

        public AuthenticationUserService(ApplicationDbcontext context)
        {
            _context = context;
        }

        bool IAuthenticationUserService.authenticating(string? username, string? password)
        {

            var usuario = _context.Tb_Usuarios.SingleOrDefault(u => u.UserName == username);

            if (usuario != null)
            {
                return username == usuario.UserName && password == usuario.Password;
            }

            return false;

        }

        void IAuthenticationUserService.saveAuthentication(HttpContext context, string userName, string password)
        {
            context.Session.SetString("userName", userName);
            context.Session.SetString("password", password);

        }

        void IAuthenticationUserService.clearAuthentication(HttpContext context)
        {
            context.Session.Remove("userName");
            context.Session.Remove("password");
        }

    }

}
