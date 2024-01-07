using blog_bakend.Models;

namespace blog_bakend.Service.Mongo
{
    public interface IMongoDBService 
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
