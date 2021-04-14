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
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _userService;

        public TweetsController(ITweetService userService)
        {
            _userService = userService;
         
        }

        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("getUsers/{id}")]
        public ActionResult<List<UserModel>> Get(string id)
        {
            List<UserModel> userModels = new List<UserModel>();
            userModels = _userService.GetUserById(id);
            if(userModels.Count()==0)
            {
                return NotFound();
            }
            return userModels;
        }

        [HttpPost("regsiter")]
        public ActionResult RegisterUser([FromBody] UserModel userModel)
        {
            _userService.RegisterUser(userModel);
            return Ok();
        }
        
        [HttpPost("login")]
        public ActionResult<List<UserModel>> Login([FromBody] UserModel userModel)
        {
            var result= _userService.Login(userModel);
            return result;
        }

        [HttpPost("changePassword")]
        public ActionResult ChangePassword(ChangePasswordModel changePassword)
        {
            bool status = false;
            try
            {
                _userService.ChangePassword(changePassword);
                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        
        [HttpGet("getUsersByUsername/{emailId}")]
        public ActionResult<List<UserModel>> GetByUsername(string emailId)
        {
            List<UserModel> userModels = new List<UserModel>();

            userModels=_userService.GetUserByUsername(emailId);

            return userModels;
           
        }
        
        [HttpPost("resetPassword")]
        public ActionResult ResetPassword(UserModel userModel)
        { 
            try
            {
                _userService.ResetPassword(userModel);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
        public IActionResult Index()
        {
            return Ok("TweetApp Web Api");
        }


    }
}
