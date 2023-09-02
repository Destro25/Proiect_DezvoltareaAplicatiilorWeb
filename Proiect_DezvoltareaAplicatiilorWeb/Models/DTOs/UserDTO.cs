﻿namespace Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs
{
    public class UserDTO
    {
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address? Address { get; set; }
    }
}
