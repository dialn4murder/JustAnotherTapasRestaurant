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
    public class IndexModel : PageModel
    {
        private readonly JustAnotherTapasRestaurant.Data.JustAnotherTapasRestaurantContext _context;

        public IndexModel(JustAnotherTapasRestaurant.Data.JustAnotherTapasRestaurantContext context)
        {
            _context = context;
        }

        public IList<MenuItem> MenuItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MenuItem = await _context.MenuItems.ToListAsync();
        }
    }
}
