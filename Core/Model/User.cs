using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
