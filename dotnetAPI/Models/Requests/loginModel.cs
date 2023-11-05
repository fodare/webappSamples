using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetAPI.Models.Requests
{
    public class LoginModel
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }
    }
}