using LearnBasRazorPageB02.Dtos;
using LearnBasRazorPageB02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnBasRazorPageB02.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogViewModel AddBlogPostRequest { get; set; }

        private readonly DatabaseContext _context;

        public AddModel(DatabaseContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAddNewPost()
        {
            var blogPost = new BlogPost
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
            };

            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/Blogs/List");

        }
    }
}
