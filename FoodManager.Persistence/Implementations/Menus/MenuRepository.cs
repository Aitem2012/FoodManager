using AutoMapper;
using FoodManager.Application.DTO.Menus;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Domain.Menus;
using Microsoft.EntityFrameworkCore;

namespace FoodManager.Persistence.Implementations.Menus
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public MenuRepository(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> CreateMenuAsync(CreateMenuDto menu, string imageUrl, CancellationToken cancellationToken)
        {
            var theMenu = _mapper.Map<Menu>(menu);
            theMenu.ImageUrl = imageUrl;
            _context.Menus.Add(theMenu);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<GetMenuResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetMenuResponseObjectDto>(theMenu));
        }

        public async Task<BaseResponse<bool>> DeleteMenuAsync(Guid menuId, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(x => x.Id.Equals(menuId));
            if (menu == null)
            {
                return new BaseResponse<bool>().CreateResponse($"No menu with Id: {menuId}", false, false);
            }
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<bool>().CreateResponse($"Menu with Id: {menuId} has been deleted successfully", true, true);
        }

        public async Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetAvailableMenuAsync()
        {
            var menus = await _context.Menus.Where(x => x.IsAvailable).ToListAsync();
            return new BaseResponse<IEnumerable<GetMenuResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetMenuResponseObjectDto>>(menus));
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> GetMenuByIdAsync(Guid menuId)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(x => x.Id.Equals(menuId));
            if (menu == null)
            {
                return new BaseResponse<GetMenuResponseObjectDto>().CreateResponse($"No menu with Id: {menuId}", false, null);
            }
            return new BaseResponse<GetMenuResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetMenuResponseObjectDto>(menu));
        }

        public async Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetMenusAsync()
        {
            var menus = await _context.Menus.ToListAsync();
            return new BaseResponse<IEnumerable<GetMenuResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetMenuResponseObjectDto>>(menus));
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> UpdateMenuAsync(UpdateMenuDto menu, CancellationToken cancellationToken)
        {
            var menuInDb = await _context.Menus.SingleOrDefaultAsync(x => x.Id.Equals(menu.MenuId));
            if (menuInDb == null)
            {
                return new BaseResponse<GetMenuResponseObjectDto>().CreateResponse($"No menu with Id: {menu.MenuId}", false, null);
            }
            var theMenu = _mapper.Map(menu, menuInDb);
            _context.Menus.Attach(theMenu);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<GetMenuResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetMenuResponseObjectDto>(theMenu));
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> UpdateMenuImageAsync(Guid menuId, string imageUrl, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(x => x.Id.Equals(menuId), cancellationToken);
            if (menu == null)
            {
                return new BaseResponse<GetMenuResponseObjectDto>().CreateResponse($"No menu with Id: {menuId}", false, null);
            }
            menu.ImageUrl = imageUrl;
            _context.Menus.Attach(menu);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<GetMenuResponseObjectDto>().CreateResponse("Image uploaded successfully", true, _mapper.Map<GetMenuResponseObjectDto>(menu));
        }
    }
}
