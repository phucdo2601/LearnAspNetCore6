using LearnBasRazorPageB02.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnBasRazorPageB02.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public BlogPost BlogPost { get; set; }

        private readonly DatabaseContext _context;
        public EditModel(DatabaseContext context)
        {
            this._context = context;
        }
        public async Task OnGet(Guid id)
        {
            BlogPost =  await _context.BlogPosts.FindAsync(id);

        }

        public async Task<IActionResult> OnPostUpdateBlog()
        {
            var existingBlog = _context.BlogPosts.Find(BlogPost.Id);
            if (existingBlog != null)
            {
                existingBlog.Heading = BlogPost.Heading;
                existingBlog.PageTitle = BlogPost.PageTitle;
                existingBlog.Content = BlogPost.Content;
                existingBlog.ShortDescription = BlogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = BlogPost.UrlHandle;
                existingBlog.PublishedDate = BlogPost.PublishedDate;
                existingBlog.Author = BlogPost.Author;
                existingBlog.Visible = BlogPost.Visible;


                await _context.SaveChangesAsync();

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteBlog()
        {
            var existingBlog = _context.BlogPosts.Find(BlogPost.Id);
            if (existingBlog != null)
            {
                _context.BlogPosts.Remove(existingBlog);

                await _context.SaveChangesAsync();

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
