using LearnBasRazorPageB01.Datas;
using LearnBasRazorPageB01.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnBasRazorPageB01.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _context;

        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }

        public EditModel(DatabaseContext context)
        {
            this._context = context;
        }
        public void OnGet(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                // Convert Domain Model
                EditEmployeeViewModel = new EditEmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Phone = employee.Phone,
                    DataOfBirth = employee.DataOfBirth,
                    Department = employee.Department,
                };
            }
        }

        public void OnPostUpdateEmployee()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = _context.Employees.Find(EditEmployeeViewModel.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.Email = EditEmployeeViewModel.Email;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.Phone = EditEmployeeViewModel.Phone;
                    existingEmployee.DataOfBirth = EditEmployeeViewModel.DataOfBirth;
                    existingEmployee.Department = EditEmployeeViewModel.Department;
                    
                    _context.SaveChanges();

                    ViewData["Message"] = "Employee created successfully!";
                }
            }

            
        }

        public IActionResult OnPostDeleteEmployee()
        {
            var existingEmployee = _context.Employees.Find(EditEmployeeViewModel.Id);

            if (existingEmployee != null)
            {
                _context.Employees.Remove(existingEmployee);

                _context.SaveChanges();

                return RedirectToPage("/Employees/List");
            }

            return Page();
        }
    }
}
