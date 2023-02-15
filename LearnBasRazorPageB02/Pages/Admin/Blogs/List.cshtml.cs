using LearnBasRazorPageB02.Models;
using LearnBasRazorPageB02.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LearnBasRazorPageB02.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly DatabaseContext _context;
        private readonly IBlogPostRepository _blogRepo;

        /*public List<BlogPost> BlogPosts { get; set; }*/
        public IEnumerable<BlogPost> BlogPosts { get; set; }

        public ListModel(DatabaseContext context, IBlogPostRepository blogRepo)
        {
            this._context = context;
            _blogRepo = blogRepo;
        }
        public async Task OnGet()
        {
            //using basic repository
            BlogPosts = await _blogRepo.GetAllPostsAsync();
        }
    }
}
