using System.ComponentModel.DataAnnotations;

namespace PastPapaer2.Model
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Order Name")]
        public string OrderName { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        // Foreign key to Products
        public int ProductId { get; set; }

        // Navigation property (for Question 5b)
        public Product Product { get; set; }

    }
}
