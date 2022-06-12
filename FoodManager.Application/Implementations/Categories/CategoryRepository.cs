using AutoMapper;
using FoodManager.Application.DTO.Categories;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Domain.Menus;
using Microsoft.EntityFrameworkCore;

namespace FoodManager.Application.Implementations.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetCategoryResponseObjectDto>> CreateCategoryAsync(CreateCategoryDto model, CancellationToken cancellationToken)
        {
            var categoryExist = await _context.Categories.AnyAsync(x => x.Name.Equals(model.Name));
            if (categoryExist)
            {
                return new BaseResponse<GetCategoryResponseObjectDto>().CreateResponse($"Category name : {model.Name} exist already", false, null);
            }
            var category = _mapper.Map<Category>(model);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<GetCategoryResponseObjectDto>().CreateResponse("Category created!", true, _mapper.Map<GetCategoryResponseObjectDto>(category));
        }

        public Task<BaseResponse<bool>> DeleteCategoryAsync(Guid menuId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<GetCategoryResponseObjectDto>> UpdateCategoryAsync(UpdateCategoryDto model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
