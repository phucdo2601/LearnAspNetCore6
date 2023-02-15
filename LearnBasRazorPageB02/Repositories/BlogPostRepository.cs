using LearnBasRazorPageB02.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnBasRazorPageB02.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DatabaseContext _context;
        public BlogPostRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlog = await GetAsync(id);
            if (existingBlog != null)
            {
                _context.BlogPosts.Remove(existingBlog);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllPostsAsync()
        {
            IEnumerable<BlogPost> res = await _context.BlogPosts.ToListAsync();
            return res;
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            BlogPost res =  await _context.BlogPosts.FindAsync(id);
            return res;
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = _context.BlogPosts.Find(blogPost.Id);
            if (existingBlog != null)
            {
                existingBlog.Heading = blogPost.Heading;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Author = blogPost.Author;
                existingBlog.Visible = blogPost.Visible;


                await _context.SaveChangesAsync();

                return existingBlog;
            }

            return null;
        }
    }
}
