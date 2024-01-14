using blog_bakend.DTOs.RequestDtos;
using blog_bakend.Models;

namespace blog_bakend.Service.Mongo
{
    public interface IMongoDBService 
    {
        Task<BlogPost> CreateAsync(CreateBlogInputDto blogPostDto);
        Task<List<BlogPost>> GetAllAsync();

        Task<BlogPost> GetBlogById(string id);

    }
}
