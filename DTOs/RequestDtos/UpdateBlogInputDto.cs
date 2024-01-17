namespace blog_bakend.DTOs.RequestDtos
{
    public class UpdateBlogInputDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Author { get; set; }

    }
}
