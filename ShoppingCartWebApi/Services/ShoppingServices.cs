using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Services
{
    public class ShoppingServices: IShoppingServices
    {
        private readonly List<ShoppingItemsModel> _productItems;
        public ShoppingServices()
        {
            _productItems = new List<ShoppingItemsModel>()
            {
                new ShoppingItemsModel
                {
                    productId = 1,
                    productDescription = "sample 1",
                    productName = "Mobile",
                    productType = "Electronics",
                    placeOrder = false,
                    pushToCart= true
                },
                new ShoppingItemsModel
                {
                    productId = 2,
                    productDescription = "sample 2",
                    productName = "HarryPotter",
                    productType = "Book",
                    placeOrder = false,
                    pushToCart= true
                },
                new ShoppingItemsModel
                {
                    productId = 3,
                    productDescription = "sample 3",
                    productName = "Pillow",
                    productType = "Beddings",
                    placeOrder = true,
                    pushToCart= false
                },
            };
        }

        public ShoppingItemsModel AddProducts(ShoppingItemsModel items)
        {
            int newproductId = _productItems.Max(x => x.productId) + 1;
            items.productId = newproductId;
            _productItems.Add(items);
            return items;
        }

        public ShoppingItemsModel GetByProductId(int productId)
        {
            return _productItems.Where(x => x.productId == productId).FirstOrDefault();
        }

        public List<ShoppingItemsModel> GetShoppingItems()
        {
            return _productItems;
        }

        public List<ShoppingItemsModel> CartToOrder(List<ShoppingItemsModel> items)
        {
            var appendList = new List<ShoppingItemsModel>();
            foreach(ShoppingItemsModel item in items)
            {
                var exisitingItem = _productItems.Find(x => x.productId == item.productId);
                if (exisitingItem != null)
                {
                    exisitingItem.placeOrder = true;
                    appendList.Add(item);
                }
            }
            return appendList;
        }
    }
}
