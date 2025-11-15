using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PastPapaer2.Data;
using PastPapaer2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastPapaer2.Pages.Orders
{
    [Authorize(Roles = "Manager, Administrator")]
    public class IndexModel : PageModel
    {
        private readonly PastPapaer2.Data.ApplicationDbContext _context;

        public IndexModel(PastPapaer2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        // Property to hold the paged list
        public PaginatedList<Order> PaginatedOrders { get; set; }

        public IList<Model.Order> Orders { get;set; } = default!;

        // REPLACED OnGetAsync
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Order> ordersIQ = from o in _context.Orders
                                          select o;

            // Note: .Include() for Product Name from 5b
            ordersIQ = ordersIQ.Include(o => o.Product);

            // Note: Add filtering logic here if needed

            switch (sortOrder)
            {
                case "name_desc":
                    ordersIQ = ordersIQ.OrderByDescending(o => o.OrderName);
                    break;
                case "Date":
                    ordersIQ = ordersIQ.OrderBy(o => o.OrderDate);
                    break;
                case "date_desc":
                    ordersIQ = ordersIQ.OrderByDescending(o => o.OrderDate);
                    break;
                default: // Name ascending
                    ordersIQ = ordersIQ.OrderBy(o => o.OrderName);
                    break;
            }

            int pageSize = 10; // From 5f
            Orders = await PaginatedList<Order>.CreateAsync(
                ordersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

