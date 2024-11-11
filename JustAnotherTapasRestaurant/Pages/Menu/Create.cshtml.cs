using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JustAnotherTapasRestaurant.Data;
using JustAnotherTapasRestaurant.Models;

namespace JustAnotherTapasRestaurant.Pages.Menu
{
    public class CreateModel : PageModel
    {
        private readonly JustAnotherTapasRestaurant.Data.JustAnotherTapasRestaurantContext _context;

        public CreateModel(JustAnotherTapasRestaurant.Data.JustAnotherTapasRestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MenuItems.Add(MenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
