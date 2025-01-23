using DigiGameShop.Models;
using DigiGameShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigiGameShop.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController(IProductServices productServices) : ControllerBase
    {
        private readonly IProductServices _productServices = productServices;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productServices.GetProductsAsync());
        }
        [HttpGet("byId")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var product = await _productServices.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateProduct newProductObj)
        {
            var product = await _productServices.AddProductAsync(newProductObj);
            if (product == null )
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "New Product created succesfully",
                id = product!.ProductId,
            });
        }
        [HttpPut()]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] AddUpdateProduct updatedProductObj)
        {
            var product = await _productServices.UpdateProductAsync(id, updatedProductObj);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Product updated succesfully",
                id
            });
        }
        [HttpDelete()]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var product = await _productServices.DeleteProductAsync(id);
            if (product == false)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Product deleted succesfully",
                id
            });
        }
    }
}
