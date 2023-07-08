
using BikeStores1.Dto;
using BikeStores1.Models;

namespace BikeStores1.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetCategories();
        Task<ServiceResponse<GetCategoryDto>> GetCategoryById(long id);
        Task<ServiceResponse<List<GetCategoryDto>>> AddCategory(AddCategoryDto newCategory);
        Task<ServiceResponse<GetCategoryDto>> UpdateCategory(UpdateCategoryDto updateCategory);
    }
}
