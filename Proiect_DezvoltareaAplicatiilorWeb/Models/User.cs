using Proiect_DezvoltareaAplicatiilorWeb.Models.Base;
using Proiect_DezvoltareaAplicatiilorWeb.Models.Enums;
using System.Text.Json.Serialization;

namespace Proiect_DezvoltareaAplicatiilorWeb.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public Address? Address { get; set; }
        public ICollection<Rental>? Rentals { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
