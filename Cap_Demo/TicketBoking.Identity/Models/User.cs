﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace TicketBoking.Identity.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
