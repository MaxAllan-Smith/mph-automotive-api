using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mph_automotive_api.Models
{
    public class SellingPrice
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal CostPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MarginPercentage { get; set; }

        // ← Remove DatabaseGeneratedOption.Computed and compute here instead
        [NotMapped]
        public decimal UnitPrice => CostPrice / (1 - MarginPercentage / 100m);

        [NotMapped]
        public decimal RRP => UnitPrice * 1.20m;
    }
}