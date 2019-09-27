using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMDB.Core.Model;
using MongoDB.Driver;

namespace MyMDB.Core.DB
{
    public sealed class MongoClient
    {
        private static MongoClient instance = null;
        private static readonly object padlock = new object();
        private static IMongoDatabase _database;

        private MongoClient()
        {
            EstablishConnection(); //.Wait()          
        }

        public static MongoClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new MongoClient();
                }
                return instance;
            }            
        }

        private static void EstablishConnection()
        {
            MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient();
            _database = client.GetDatabase("localdb");
        }

        public static void InsertResult(Media res)
        {
            try
            {
                _database.GetCollection<Media>("results").InsertOneAsync(res);
            } catch (Exception e)
            {
                Console.WriteLine("messed up here " + e.StackTrace);
            }
        }

        public static void DisplayContent()
        {
            var documents = _database.GetCollection<Media>("results").Find(_ => true).ToListAsync();
            Console.WriteLine(documents);
        }
    }
}
