using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myasp.Models;
using System;

namespace myasp.Pages
{
    public class CreateCustomerModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly AppDbContext _db;

        public CreateCustomerModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} added";
            return RedirectToPage("/customer/list");
        }

        public async Task<IActionResult> OnPostAddHundredAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Customer.Id = Customer.Id + (int)DateTime.Now.Ticks;
            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer id added 100 with name {Customer.Name} added";
            return Page();
        }
    }
}