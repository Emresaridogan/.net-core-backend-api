using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getcategories")]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetCategories();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcategorybyid")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var result = _categoryService.GetCategoryById(categoryId);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addcategory")]
        public IActionResult AddProduct(Category category)
        {
            var result = _categoryService.AddCategory(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecategory")]
        public IActionResult UpdateProduct(Category category)
        {
            var result = _categoryService.UpdateCategory(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletecategory")]
        public IActionResult DeleteProduct(Category category)
        {
            var result = _categoryService.DeleteCategory(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
