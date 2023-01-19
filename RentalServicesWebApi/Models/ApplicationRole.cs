
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RentalServicesWebApi.Models

{
    public class ApplicationRole : IdentityRole
    {
       
        public string? Description { get; set; }
    }
}