﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Models.ViewModels
{
    public class RegisterVm
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string Email { get; set; }
       
        public long PhoneNumber { get; set; }
       
        public string Password { get; set; }
       
        public string ConfirmPassword { get; set; }
    }
}
