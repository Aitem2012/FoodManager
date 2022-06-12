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

        public async Task<BaseResponse<bool>> DeleteCategoryAsync(Guid categoryId)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id.Equals(categoryId));
            if (category == null)
            {
                return new BaseResponse<bool>().CreateResponse($"No category with Id: {categoryId}", false, false);
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(new CancellationToken());
            return new BaseResponse<bool>().CreateResponse($"Category with Id: {categoryId} has been deleted", true, true);
        }

        public async Task<BaseResponse<IEnumerable<GetCategoryResponseObjectDto>>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.Include(x => x.Menus).ToListAsync();
            return new BaseResponse<IEnumerable<GetCategoryResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetCategoryResponseObjectDto>>(categories));
        }

        public async Task<BaseResponse<GetCategoryResponseObjectDto>> GetCategoryByIdAsync(Guid categoryId)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id.Equals(categoryId));
            if (category == null)
            {
                return new BaseResponse<GetCategoryResponseObjectDto>().CreateResponse($"No category with Id: {category}", false, null);
            }
            return new BaseResponse<GetCategoryResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetCategoryResponseObjectDto>(category));
        }

        public async Task<BaseResponse<GetCategoryResponseObjectDto>> UpdateCategoryAsync(UpdateCategoryDto model, CancellationToken cancellationToken)
        {
            var categoryIndb = await _context.Categories.SingleOrDefaultAsync(x => x.Id.Equals(model.CategoryId));
            if (categoryIndb == null)
            {
                return new BaseResponse<GetCategoryResponseObjectDto>().CreateResponse($"No category with Id: {model.CategoryId}", false, null);
            }
            var category = _mapper.Map(model, categoryIndb);
            _context.Categories.Attach(category);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<GetCategoryResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetCategoryResponseObjectDto>(category));
        }
    }
}
