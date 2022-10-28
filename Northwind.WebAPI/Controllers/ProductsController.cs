using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getproducts")]
        //[Authorize(Roles = "Product.List")]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductsbycategory")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var result = _productService.GetProductsByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductbyid")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetProductById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.AddProduct(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateproduct")]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.UpdateProduct(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteproduct")]
        public IActionResult DeleteProduct(Product product)
        {
            var result = _productService.DeleteProduct(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
