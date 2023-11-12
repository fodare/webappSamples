using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnetAPI.Models;
using dotnetAPI.Models.Requests;
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
        private readonly IPostService _postInterface;

        [ActivatorUtilitiesConstructor]
        public UserController(ILogger<UserController> logger, IUserInterface userInterface, IPostService postInterface)
        {
            _logger = logger;
            _userInterface = userInterface;
            _postInterface = postInterface;
        }

        [HttpGet("getusers", Name = "GetUsers")]
        public ActionResult GetUsers()
        {
            var res = _userInterface.GetUsers();
            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpPost("createuser", Name = "CreateUser")]
        public ActionResult CreateUser(UserModel user)
        {
            var res = _userInterface.CreateUser(user);
            return Ok(res);
        }

        [HttpPost("login", Name = "Login")]
        public ActionResult Login(LoginModel user)
        {
            var response = _userInterface.Login(user);
            return Ok(response);
        }

        [HttpGet("getposts", Name = "GetPosts")]
        public ActionResult GetPosts()
        {
            var response = _postInterface.GetPosts();
            if (response.success != true)
            {
                return StatusCode(500, response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("getpost/{id}", Name = "GetPostById")]
        public ActionResult Getpost(int id)
        {
            var response = _postInterface.GetPost(id);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("createpost", Name = "CreatePost")]
        public ActionResult CreatePost(PostModel newpost)
        {
            var response = _postInterface.CreatePost(newpost);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("deletepost/{postId}", Name = "DeletePost")]
        public ActionResult DeletePost(int postId)
        {
            var response = _postInterface.DeletePost(postId);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}