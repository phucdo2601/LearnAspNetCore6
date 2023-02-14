using LearnBasRazorPageB01.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnBasRazorPageB01.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly DatabaseContext _context;

        public List<Employee> Employees { get; set; }
        public ListModel(DatabaseContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
            Employees = _context.Employees.ToList();
        }
    }
}
