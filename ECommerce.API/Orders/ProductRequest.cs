namespace ECommerce.API.Orders
{
    public class ProductRequest
	{
        public decimal Price { get; set; }

        public string Name { get; set; }

		public string ImageUrl { get; set; }
    }
}