using Microsoft.AspNetCore.Mvc;
using ShoppingCartWebApi.Controllers;
using ShoppingCartWebApi.Models;
using ShoppingCartWebApi.Services;

namespace ShoppingTest
{
    public class ShoppingEndControllerTest
    {
        ShoppingEndController _controller;
        IShoppingServices _service;
        public ShoppingEndControllerTest()
        {
            _service = new ShoppingServices();
            _controller = new ShoppingEndController(_service);
        }

        [Fact]
        public void GetAllProducts_Success()
        {
            //Arrange
            //Act
            var result = _controller.GetProducts();
            var resultType = result as OkObjectResult;
            var resultList = resultType.Value as List<ShoppingItemsModel>;

            //Assert
            Assert.NotNull(result);
            Assert.IsType <List<ShoppingItemsModel>> (resultType.Value);
            Assert.Equal(3, resultList.Count);

        }

        [Fact]
        public void GetProductById_Success()
        {
            //Arrange
            int valid_productId = 1;
            int invalid_productId = 6;

            //Act
            var errorResult = _controller.GetByProductId(invalid_productId);
            var successResult = _controller.GetByProductId(valid_productId);
            var successModel = successResult as OkObjectResult;
            var fetchedProduct = successModel.Value as ShoppingItemsModel;

            //Assert
            Assert.Equal(1, fetchedProduct.productId);

        }
        [Fact]
        public void Add_Product_Success()
        {
            ShoppingItemsModel product = new ShoppingItemsModel()
            {
                productId = 4,
                productName = "Test",
                productDescription = "sample description",
                productType = "sample type 1",
                placeOrder = false,
                pushToCart = true
            };

            var response = _controller.AddProducts(product);
            Assert.IsType<CreatedAtActionResult>(response);

            var createdProduct = response as CreatedAtActionResult;
            Assert.IsType<ShoppingItemsModel>(createdProduct.Value);

            var createdItems = createdProduct.Value as ShoppingItemsModel;

            Assert.Equal("Test", createdItems.productName);
            Assert.False(createdItems.placeOrder);
        }

        [Fact]
        public void MoveCartToShopping_Success()
        {
            //Arrange
            var product = new List<ShoppingItemsModel>()
            {
                new ShoppingItemsModel() {
                productId = 2,
                productName = "Test",
                productDescription = "sample description",
                productType = "sample type",
                placeOrder = false,
                pushToCart = true
                }
            };
            //Assert
            var response = _controller.UpdateProducts(product);
            Assert.IsType<CreatedAtActionResult>(response);

            var createdProduct = response as CreatedAtActionResult;
            Assert.IsType<List<ShoppingItemsModel>>(createdProduct.Value);
        

        }
    }
}
