
using AutoMapper;
using BikeStores1.Data;
using BikeStores1.Dto;
using BikeStores1.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Tar;

namespace BikeStores1.Services.CategoryService
{
    public class CagegoryService : ICategoryService

    {
        private static List<Category> categories = new List<Category>
        {
            new Category(),
            new Category{Id =  1, Name = "Water"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CagegoryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCategoryDto>>> AddCategory(AddCategoryDto newCategory)
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>(); 
            var category = _mapper.Map<Category>(newCategory);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            
            serviceResponse.Data = 
                await _context.Categories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToListAsync();
            return serviceResponse;
        }

        //public async Task<ServiceResponse<List<GetCategoryDto>>> DeleteCategory(long id)
        //{
        //    var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
        //    try
        //    {
        //        var category =
        //            await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        //        if (category == null)
        //        {
        //            throw new Exception($"Category cannot find id : {id}");
        //        }
        //        _context.Categories.Remove(category);

        //        await _context.SaveChangesAsync();

        //        serviceResponse.Data =
        //            await _context.Categories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.Success = false;
        //        serviceResponse.Message = ex.Message;
        //    }
        //    return serviceResponse;
        //}


        public async Task<ServiceResponse<List<GetCategoryDto>>> GetCategories()
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
            var dbCategories = await _context.Categories.ToListAsync();
            serviceResponse.Data = dbCategories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDto>> GetCategoryById(long id)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            try
            {
                var dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (dbCategory == null)
                {
                    throw new Exception($"Categor cannot find id: {id}");
                }
                ///var category = categories.FirstOrDefault(c => c.Id == id);
                serviceResponse.Data = _mapper.Map<GetCategoryDto>(dbCategory);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDto>> UpdateCategory(UpdateCategoryDto updateCategory)
        {

            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            try
            {
                var category = 
                    await _context.Categories.FirstOrDefaultAsync(c => c.Id == updateCategory.Id);
                if(category == null)
                {
                    throw new Exception($"Category cannot find id {updateCategory.Id}");
                }
                category.Name = updateCategory.Name;
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCategoryDto>(category);
            } 
            catch (Exception ex)

            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
                
            
            


            return serviceResponse;
        }
    }
}
