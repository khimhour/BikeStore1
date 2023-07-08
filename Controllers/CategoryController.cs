
using BikeStores1.Dto;
using BikeStores1.Models;
using BikeStores1.Services.CategoryService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BikeStores1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //private static List<Category> categories = new List<Category>
        //{
        //    new Category(),
        //    new Category{Id =  1, Name = "Water"}
        //};
        [HttpGet("GetAll")]
       
        public async Task<ActionResult<ServiceResponse<List<GetCategoryDto>>>> Get()
        { 
            return Ok(await _categoryService.GetCategories());
        }
        [HttpGet("{id}")]
        ///////////////////
        //public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> Deletecategory(long id)
        //{
        //    var response = await _categoryService.DeleteCategory(id);
        //    if (response.Data == null)
        //    {
        //        return NotFound(response);
        //    }
        //    return Ok(response);

        //}
        /////

        public async  Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetById(long id)
        {
            var response = await _categoryService.GetCategoryById(id);
            if (response.Data == null)
            {
                return NotFound(response);

            }
            return Ok();
           // return Ok(await _categoryService.GetCategoryById(id));

        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> AddCategory(AddCategoryDto newCategory)
        {
            return Ok(await _categoryService.AddCategory(newCategory));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> updateCategory (UpdateCategoryDto updateCategory)
        {
            var response = await _categoryService.UpdateCategory(updateCategory);
            if(response.Data == null)
            {
                return NotFound(null);
            }
            return Ok(response);
        }
    }
}