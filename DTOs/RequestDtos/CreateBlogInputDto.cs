namespace blog_bakend.DTOs.RequestDtos
{
    public class CreateBlogInputDto
    {
        public string? BlogTitle { get; set; }

        public string? BlogDescription { get; set;}

        public string? BlogAuthor { get; set; }

        public List<BlogImageDto>? BlogImageDtos { get; set; }

        public DateTime? CreatedAt { get; set; } = default(DateTime?);

    }

    public class BlogImageDto 
    {
        public IFormFile? FormFile{ get; set; }

    }
}
