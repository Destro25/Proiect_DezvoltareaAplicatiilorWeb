using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.Enums;

namespace Proiect_DezvoltareaAplicatiilorWeb.Helpers.Attributes
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public Authorization(params Role[] roles) 
        {
            _roles = roles;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context) 
        {
            var unauthorizationStatusObject = new JsonResult(new { Message = "Unauthorized access." }) { StatusCode = StatusCodes.Status401Unauthorized };

            if (_roles == null)
            {
                context.Result = unauthorizationStatusObject;
            }
            var user = (User)context.HttpContext.Items["User"];
            //User? user = context.HttpContext.Items["User"] as User;

            if (user == null || !_roles.Contains(user.Role)) 
            {
                context.Result = unauthorizationStatusObject;
                //Console.WriteLine(user.UserName);
            }
        }
    }
}
