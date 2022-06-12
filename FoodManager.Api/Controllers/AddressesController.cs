using FoodManager.Application.DTO.Addresses;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class AddressesController : ControllerBase
    {
        private readonly ILogger<AddressesController> _controller;
        private readonly IAddressService _addressService;
        public AddressesController(ILogger<AddressesController> controller, IAddressService addressService)
        {
            _controller = controller;
            _addressService = addressService;
        }

        /// <summary>
        /// creates a new user address
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("createaddress",Name = nameof(CreateAddress)), ProducesResponseType(typeof(GetAddressResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressDto model)
        {
            return Ok(await _addressService.CreateAddress(model, new CancellationToken()));
        }

        /// <summary>
        /// Update a user address
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("updateuseraddress", Name = nameof(UpdateUserAddress)), ProducesResponseType(typeof(GetAddressResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateUserAddress([FromBody] UpdateAddressDto model)
        {
            return Ok(await _addressService.UpdateAddressAsync(model, new CancellationToken()));
        }

        /// <summary>
        /// Get user address by Id
        /// </summary>
        /// <param name="appUserId"></param>
        /// <returns></returns>
        [HttpGet("{appUserId}", Name = nameof(GetUserAddressByUserId)), ProducesResponseType(typeof(GetAddressResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetUserAddressByUserId([FromRoute] string appUserId)
        {
            return Ok(await _addressService.GetAddress(appUserId));
        }
    }
}
