using System.ComponentModel.DataAnnotations;

namespace mph_automotive_api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(100)]
        public string ProductCode { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        public int? StockQty { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
