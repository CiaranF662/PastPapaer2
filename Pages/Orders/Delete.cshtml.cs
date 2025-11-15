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
    public class DeleteModel : PageModel
    {
        private readonly PastPapaer2.Data.ApplicationDbContext _context;

        public DeleteModel(PastPapaer2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                Orders = orders;
                _context.Orders.Remove(Orders);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
