using System.ComponentModel.DataAnnotations;
using static NuGet.Packaging.PackagingConstants;

namespace PastPapaer2.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int StockLevel { get; set; }

        // Navigation property for Orders
        public ICollection<Order> Orders { get; set; }

    }
}
