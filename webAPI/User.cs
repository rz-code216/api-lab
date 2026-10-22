using System.ComponentModel.DataAnnotations;

namespace webAPI
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }

    public class UserLogIn
    {
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}