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
        private readonly IUserService _userService;
        private readonly ITweetService _tweetService;
        public TweetsController(IUserService userService,ITweetService tweetService)
        {
            _userService = userService;
            _tweetService = tweetService;
        }

        #region User
        [HttpGet("users/all")]
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

        [HttpPost("resetPassword")]
        public ActionResult ResetPassword(ChangePasswordModel changePassword)
        {
            bool status = false;
            try
            {
                _userService.ResetPassword(changePassword);
                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        
        [HttpGet("user/search/{username}")]
        public ActionResult<List<UserModel>> GetByUsername(string username)
        {
            List<UserModel> userModels = new List<UserModel>();

            userModels=_userService.GetUserByUsername(username);

            return userModels;
           
        }

        [HttpPost("forgotPassword")]
        public ActionResult ForgotPassword(UserModel userModel)
        { 
            try
            {
                _userService.ForgotPassword(userModel);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
       /* public IActionResult Index()
        {
            return Ok("TweetApp Web Api");
        }*/
        #endregion

        #region Tweets

        [HttpPost("{username}/add")]
        public ActionResult<TweetModel> PostTweet([FromBody] TweetModel tweetModel)
        {
            _tweetService.postTweet(tweetModel);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<List<TweetModel>> getTweet()
        {
            return _tweetService.getAllTweets();
        }

        [HttpGet("{username}")]
        public ActionResult<List<TweetModel>> getUserTweets(string username)
        {
            return _tweetService.getAllTweetsOfUser(username);
        }

        [HttpPut("update/{id}")]
        public ActionResult<List<TweetModel>> updateTweet([FromBody] TweetModel tweetModel)
        {
            bool status = false;
            try
            {
                status=_tweetService.UpdateTweet(tweetModel);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        #endregion
    }
}
