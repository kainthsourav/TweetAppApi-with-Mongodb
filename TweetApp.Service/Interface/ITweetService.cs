using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.DAL.Models;

namespace TweetApp.Service.Interface
{
   public interface ITweetService
    {
        List<TweetModel> getAllTweets();
        List<TweetModel> getAllTweetsOfUser(string username);
        List<TweetModel> postTweet(TweetModel tweetModel);

        bool UpdateTweet(string id, string tweetdesc);
        bool DeleteTweet(string id);
        bool LikeTweet(string id);
        bool ReplyTweet(string id, TweetModel tweetModel);


    }
}
