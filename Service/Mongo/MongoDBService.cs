using blog_bakend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using blog_bakend.DTOs.RequestDtos;

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

        public async Task<BlogPost> CreateAsync(CreateBlogInputDto blogPostDto) 
        {
            try
            {
                List<byte[]> blogImagesList = new List<byte[]>();
                var blogPost = new BlogPost
                {
                    Title = blogPostDto.BlogTitle,
                    Description = blogPostDto.BlogDescription,
                    Author = blogPostDto.BlogAuthor,
                    CreatedDate = DateTime.Now,
                    BlogImages = blogImagesList
                };

                // Check there are any image

                if (blogPostDto.BlogImageDtos != null) 
                {
                    foreach (var blogImageDto in blogPostDto.BlogImageDtos) 
                    {
                        // Convert IFormFile to byte array
                        using (var stream = new MemoryStream())

                        {
                            blogImageDto.FormFile?.CopyTo(stream);
                            var imageData = stream.ToArray();
                            blogImagesList.Add(imageData);
                        }
                    }
                }

               await _blogPostCollection.InsertOneAsync(blogPost);

               return blogPost; 
          
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


        



        public async Task<List<BlogPost>> GetAllAsync() 
        {
            try
            {
                return await _blogPostCollection.Find(new BsonDocument()).ToListAsync();

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<BlogPost> GetBlogById(string id)
        {
            try 
            {
                var blog = await _blogPostCollection.Find(Builders<BlogPost>.Filter.Eq("Id", id)).FirstOrDefaultAsync();

                return blog;
                
            }catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }



    }
}
