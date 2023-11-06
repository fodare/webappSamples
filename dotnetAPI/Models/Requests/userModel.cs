using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace dotnetAPI.Models
{
    public class UserModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required bool IsAdmin { get; set; }
    }
}