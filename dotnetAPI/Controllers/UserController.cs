using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnetAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnetAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserInterface _userInterface;

        public UserController(ILogger<UserController> logger, IUserInterface userInterface)
        {
            _logger = logger;
            _userInterface = userInterface;
        }

        [HttpGet("GetUsers", Name = "GetUsers")]
        public ActionResult GetUsers()
        {
            var res = _userInterface.GetUsers();
            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
    }
}