﻿using Microsoft.AspNetCore.Identity;

namespace Calibration_Management_System.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
