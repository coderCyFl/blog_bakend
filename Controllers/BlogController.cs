using AutoMapper;
using blog_bakend.DTOs.OutputDtos;
using blog_bakend.Models;
using blog_bakend.Service.Mongo;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace blog_bakend.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly IMongoDBService _mongoDBService;
        private readonly IMapper _mapper;

        public BlogController(MongoDBService mongoDBService, IMapper mapper)
        {
            _mongoDBService = mongoDBService;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task <BlogpostOutputDto> CreateBlog ([FromBody] BlogPost blogPost) 
        {
            var result = await _mongoDBService.CreateAsync(blogPost);

            var outputDto = _mapper.Map<BlogpostOutputDto>(result);    

            return outputDto;
        }
    }
}
