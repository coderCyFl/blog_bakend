using AutoMapper;
using blog_bakend.DTOs.OutputDtos;
using blog_bakend.Models;

namespace blog_bakend.Mappings
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<BlogPost, BlogpostOutputDto>()
                .ForMember(dest => dest.BlogId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BlogTitleName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.BlogAuthorName, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.BlogImages, opt => opt.MapFrom(src => src.BlogImages))
                .ForMember(dest => dest.BlogPostCreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
        }
    }

}
