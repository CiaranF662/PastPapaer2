using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PastPapaer2.Data;
using PastPapaer2.Model;

namespace PastPapaer2.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PastPapaer2.Data.ApplicationDbContext _context;

        public IndexModel(PastPapaer2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
