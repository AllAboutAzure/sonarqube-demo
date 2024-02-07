namespace ShoppingCartWebApi.Models
{
    public class ShoppingItemsModel
    {
        public int productId { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public string productType { get; set; }

        public bool placeOrder { get; set; }

        public bool pushToCart { get; set; }

    }
}
