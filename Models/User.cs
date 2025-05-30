using System.ComponentModel.DataAnnotations;

namespace mph_automotive_api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(150)]
        public string Password { get; set; }

        [StringLength(150)]
        public string? FirstName { get; set; }

        [StringLength(150)]
        public string? LastName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
