using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JustAnotherTapasRestaurant.Data;
using JustAnotherTapasRestaurant.Models;

namespace JustAnotherTapasRestaurant.Pages.Menu
{
    public class DetailsModel : PageModel
    {
        private readonly JustAnotherTapasRestaurant.Data.JustAnotherTapasRestaurantContext _context;

        public DetailsModel(JustAnotherTapasRestaurant.Data.JustAnotherTapasRestaurantContext context)
        {
            _context = context;
        }

        public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            else
            {
                MenuItem = menuitem;
            }
            return Page();
        }
    }
}
