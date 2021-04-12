using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.DAL.Models;

namespace TweetApp.Repository.Implementation
{
    public class TweetRepository
    {
        private readonly IMongoCollection<TweetModel> _tweetData;

        public TweetRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tweetData = database.GetCollection<TweetModel>("TweetData");
        }
    }
}
