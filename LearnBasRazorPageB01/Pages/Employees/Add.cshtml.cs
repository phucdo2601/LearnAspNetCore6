using LearnBasRazorPageB01.Datas;
using LearnBasRazorPageB01.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LearnBasRazorPageB01.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly DatabaseContext _context;

        public AddModel(DatabaseContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public AddNewEmployeeViewModel AddEmployeeRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() {

            var employeeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                Phone = AddEmployeeRequest.Phone,
                DataOfBirth = AddEmployeeRequest.DataOfBirth,
                Department = AddEmployeeRequest.Department,
            };

            _context.Employees.Add(employeeDomainModel);

            _context.SaveChanges();

            ViewData["Message"] = "Employee created successfully!";
        }
    }
}
