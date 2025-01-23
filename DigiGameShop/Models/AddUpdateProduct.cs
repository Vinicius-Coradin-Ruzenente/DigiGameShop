namespace DigiGameShop.Models
{
    public class AddUpdateProduct
    {        
        public required string ProductName { get; set; }
        public required float Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public required string Description { get; set; }
        public required string ProductImagePath { get; set; }
        public int DiscountPercentage { get; set; }
        public required int ProductStock { get; set; }
    }
}
