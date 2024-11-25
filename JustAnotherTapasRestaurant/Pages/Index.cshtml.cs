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


        // Holds the database
		private readonly JustAnotherTapasRestaurantContext _context;

        // Constructor to inject our database into the variable
        public IndexModel(JustAnotherTapasRestaurantContext context)
        {
            _context = context;
        }

        // List that holds all data from MenuItem table
        public IList<MenuItem> MenuItem { get; set; } = default!;

        [BindProperty]
        public string Search { get; set; }

        // Populate the list with the database data
        public void OnGet()
        {
            MenuItem = _context.MenuItems.FromSqlRaw("Select * FROM MenuItem").ToList();
        }

        // Code behind the handler OnPostSearch
        public IActionResult OnPostSearch()
        {
            MenuItem = _context.MenuItems.FromSqlRaw
                ("SELECT * FROM MenuItem WHERE item LIKE '" + Search + "%'").ToList();
            return Page();
        }
    }
}
