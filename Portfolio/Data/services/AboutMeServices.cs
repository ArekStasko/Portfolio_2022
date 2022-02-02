﻿using MongoDB.Driver;
using MongoDB.Bson;
using Portfolio.Models;

namespace Portfolio.Data.services
{
    public class AboutMeServices
    {
        private IMongoDatabase _database;
        public AboutMeServices(string db)
        {
            var client = new MongoClient();
            _database = client.GetDatabase(db);
        }

        public AboutMe GetAboutMe()
        {
            var collection = GetAboutCollection();
            return collection.Find(new BsonDocument()).ToList()[0];
        }

        private IMongoCollection<AboutMe> GetAboutCollection() => _database.GetCollection<AboutMe>("About");
    }
}
