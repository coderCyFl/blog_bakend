using blog_bakend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace blog_bakend.Service.Mongo
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoCollection<BlogPost> _blogPostCollection;
        public MongoDBService(IOptions<MongoDBSetting> mongoDBsettings) {
            MongoClient mongoClient = new MongoClient(mongoDBsettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(mongoDBsettings.Value.DatabaseName);
            _blogPostCollection = mongoDatabase.GetCollection<BlogPost>(mongoDBsettings.Value.CollectionName);

        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost) 
        {
            try
            {
                // Just Return Entity
                await _blogPostCollection.InsertOneAsync(blogPost);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return blogPost;
        }
    }
}
