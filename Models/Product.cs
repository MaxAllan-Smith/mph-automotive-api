using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mph_automotive_api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        
        public int SupplierId { get; set; }

        [Required, StringLength(100)]
        public string ProductCode { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        public int StockQty { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<SellingPrice> SellingPrices { get; set; } = new List<SellingPrice>();

    }
}
