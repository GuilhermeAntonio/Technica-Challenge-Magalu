using static System.Net.Mime.MediaTypeNames;

namespace Fase2.Models
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public UserModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
