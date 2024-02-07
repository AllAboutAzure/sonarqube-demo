using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Services
{
    public interface IShoppingServices
    {
        List<ShoppingItemsModel> GetShoppingItems();
        ShoppingItemsModel GetByProductId(int productId);
        ShoppingItemsModel AddProducts(ShoppingItemsModel items);
        List<ShoppingItemsModel> CartToOrder(List<ShoppingItemsModel> items);
    }
}
