using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVC.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public required string Name { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public long CategoryId { get; set; }
        public Category? Category { get; set; }

        public long SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}