using AutoMapper;
using blog_bakend.DTOs.OutputDtos;
using blog_bakend.DTOs.RequestDtos;
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
        [Route("CreateBlog")]
        public async Task <BlogpostOutputDto> CreateBlog (CreateBlogInputDto blogPost) 
        {
            var result = await _mongoDBService.CreateAsync(blogPost);

            var outputDto = _mapper.Map<BlogpostOutputDto>(result);    

            return outputDto;
        }

        [HttpGet]
        [Route("GetAllBlog")]
        public async Task<List<BlogpostOutputDto>> GetAllBlogPost() 
        {
            var blogPostList = await _mongoDBService.GetAllAsync();

            return _mapper.Map<List<BlogpostOutputDto>>(blogPostList);
        }

        [HttpGet]
        [Route("GetBlog/{id}")]
        public async Task<BlogpostOutputDto> GetSingleBlogPost(string id) 
        {
            var singleBlog = await _mongoDBService.GetBlogById(id);

            return _mapper.Map<BlogpostOutputDto>(singleBlog);

        }

    }
}
