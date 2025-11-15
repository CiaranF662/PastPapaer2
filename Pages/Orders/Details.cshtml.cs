using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PastPapaer2.Data;
using PastPapaer2.Model;

namespace PastPapaer2.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly PastPapaer2.Data.ApplicationDbContext _context;

        public DetailsModel(PastPapaer2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }
            else
            {
                Orders = orders;
            }
            return Page();
        }
    }
}
