using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.DAL.Models;
using TweetApp.Repository.Interface;
using TweetApp.Service.Interface;

namespace TweetApp.Service.Implementation
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        public TweetService(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }
        public bool DeleteTweet(string id)
        {
            throw new NotImplementedException();
        }

        public List<TweetModel> getAllTweets()
        {
            return _tweetRepository.FindAll();
        }

        public List<TweetModel> getAllTweetsOfUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool LikeTweet(string id)
        {
            throw new NotImplementedException();
        }

        public List<TweetModel> postTweet(TweetModel tweetModel)
        {
            throw new NotImplementedException();
        }

        public bool ReplyTweet(string id, TweetModel tweetModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTweet(string id, string tweetdesc)
        {
            throw new NotImplementedException();
        }
    }
}
