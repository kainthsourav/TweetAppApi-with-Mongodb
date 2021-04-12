using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TweetApp.DAL.Models;
using TweetApp.Service.Interface;

namespace TweetAppApi
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserdataController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserdataController(IUserService userService)
        {
            _userService = userService;
         
        }

        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<List<UserModel>> Get(int id)
        {
            List<UserModel> userModels = new List<UserModel>();
            userModels = _userService.GetUserById(id);
            if(userModels.Count()==0)
            {
                return NotFound();
            }
            return userModels;
        }

        [HttpPost]
        public ActionResult RegisterUser([FromBody] UserModel userModel)
        {
            _userService.RegisterUser(userModel);
            return Ok();
        }
        public IActionResult Index()
        {
            return Ok("TweetApp Web Api");
        }
    }
}
