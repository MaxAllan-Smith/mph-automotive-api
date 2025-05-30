namespace mph_automotive_api.Models.DTOs
{
    public class ProductWithPricesDto
    {
        public Product Product { get; set; }
        public List<SellingPrice> SellingPrices { get; set; }
    }
}
