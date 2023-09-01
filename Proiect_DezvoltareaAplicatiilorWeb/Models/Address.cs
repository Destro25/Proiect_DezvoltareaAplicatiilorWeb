using Proiect_DezvoltareaAplicatiilorWeb.Models.Base;

namespace Proiect_DezvoltareaAplicatiilorWeb.Models
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int IntercomNumber { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
