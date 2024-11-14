using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JustAnotherTapasRestaurant.Data;
using JustAnotherTapasRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace JustAnotherTapasRestaurant.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;



		private readonly JustAnotherTapasRestaurantContext _context;

        public IndexModel(JustAnotherTapasRestaurantContext context)
        {
            _context = context;
        }

        public IList<MenuItem> MenuItem { get; set; } = default!;

        [BindProperty]
        public string Search { get; set; }

        public void OnGet()
        {
            MenuItem = _context.MenuItems.FromSqlRaw("Select * FROM MenuItem").ToList();
        }

        public IActionResult OnPostSearch()
        {
            MenuItem = _context.MenuItems.FromSqlRaw
                ("SELECT * FROM MenuItem WHERE item LIKE '" + Search + "%'").ToList();
            return Page();
        }
    }
}
