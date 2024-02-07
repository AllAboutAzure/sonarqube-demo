using Microsoft.AspNetCore.Mvc;
using ShoppingCartWebApi.Models;
using ShoppingCartWebApi.Services;

namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingEndController : ControllerBase
    {
        private readonly IShoppingServices _service;

        public ShoppingEndController(IShoppingServices service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            var products = _service.GetShoppingItems();
            return Ok(products);
        }
       
        [HttpGet("{id}")]
        public ActionResult GetByProductId(int id)
        {
            var productIdMatch = _service.GetByProductId(id);
            return Ok(productIdMatch);
        }

        [HttpPost]
        public ActionResult AddProducts([FromBody] ShoppingItemsModel newProduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newItem = _service.AddProducts(newProduct);
            return CreatedAtAction("GetProducts", newItem);
        }

        [HttpPut]
        public ActionResult UpdateProducts([FromBody] List<ShoppingItemsModel> updateProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedItem = _service.CartToOrder(updateProducts);
            return CreatedAtAction("GetProducts", updatedItem);
        }
    }
}
