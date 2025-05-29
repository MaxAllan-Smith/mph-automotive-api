using System.ComponentModel.DataAnnotations;

namespace mph_automotive_api.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(5)]
        public string SupplierCode { get; set; }

        [Required, StringLength(100)]
        public string SupplierName { get; set; }

        [Required, StringLength(255)]
        public string Address1 { get; set; }

        [Required, StringLength(255)]
        public string Address2 { get; set; }

        [Required, StringLength(255)]
        public string Address3 { get; set; }

        [Required, StringLength(255)]
        public string Address4 { get; set; }

        public string? Address5 { get; set; }

        [Required, StringLength(15)]
        public string PostCode { get; set; }

        public string? Website { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
