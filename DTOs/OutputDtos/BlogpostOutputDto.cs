namespace blog_bakend.DTOs.OutputDtos
{
    public class BlogpostOutputDto
    {
        public string BlogId { get; set; }

        public string BlogTitleName { get; set;}

        public string BlogDescription { get; set;}
        
        public string BlogAuthorName { get; set;} 

        public List<Byte[]>? BlogImages { get; set;}

        public DateTime BlogPostCreatedDate { get; set;}
    }
}
