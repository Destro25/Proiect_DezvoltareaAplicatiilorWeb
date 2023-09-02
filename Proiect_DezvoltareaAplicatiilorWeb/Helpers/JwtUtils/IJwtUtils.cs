using Proiect_DezvoltareaAplicatiilorWeb.Models;

namespace Proiect_DezvoltareaAplicatiilorWeb.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
