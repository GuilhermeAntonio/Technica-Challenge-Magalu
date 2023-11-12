using Fase3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fase_3.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public DbSet<UserModel> Tb_Usuarios { get; set; }

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {


        }

        
    }
}
