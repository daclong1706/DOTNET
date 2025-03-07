using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVC.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public required string Name { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public long CategoryId { get; set; }
        public Category? Category { get; set; }

        public long Suppliers { get; set; }
        public Supplier? Supplier { get; set; }
    }
}