using System.ComponentModel.DataAnnotations;

namespace Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string? LastName { get; set; }
    }
}
