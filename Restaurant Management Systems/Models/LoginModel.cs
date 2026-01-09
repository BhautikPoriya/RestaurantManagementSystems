using System.ComponentModel.DataAnnotations;

namespace Restaurant_Management_Systems.Models
{
    public class LoginModel
    {
        public bool UsernamesEnabled { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
