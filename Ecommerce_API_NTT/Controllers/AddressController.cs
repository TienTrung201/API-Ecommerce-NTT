using Ecommerce_API.Service.Model;
using Ecommerce_API.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API_NTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        //get
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var AddressesResponse = await _addressService.GetAllAddress();
            return Ok(new ResponseModel
            {
                Data = AddressesResponse
            }); 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress([FromRoute] int? id)
        {

            if (!id.HasValue)
            {
                return BadRequest(new ResponseModel() { Status = 400, Title = "addressId is required" });
            }
            try
            {
                var address = await _addressService.GetAddressById(id.Value);
                return Ok(new ResponseModel
                {
                    Data = address
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseModel() { Status = 500, Title = ex.Message, IsSuccess = false }
                );
            }
        }
        //post

        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] AddressRequestDto addressRequestDto)
        {
            if (addressRequestDto == null)
            {
                return BadRequest(new ResponseModel() { Status = 400, Title = "address is required" });
            }
            try
            {
                var newAddress = await _addressService.CreateAddress(addressRequestDto);
                return Ok(new ResponseModel
                {
                    Status = 201,
                    Data = newAddress
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseModel() { Status = 500, Title = ex.Message }
                );
            }


        }
        //update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int? id, [FromBody] AddressRequestDto addressRequestDto)
        {
            if (!id.HasValue || addressRequestDto==null)
            {
                return BadRequest(new ResponseModel() { Status = 400, Title = "address is required" });
            }
            try
            {
                var updateAddress = await _addressService.UpdateAddress(id.Value, addressRequestDto);
                return Ok(new ResponseModel
                {
                    Data = updateAddress
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseModel() { Status = 500, Title = ex.Message }
                );
            }
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new ResponseModel() { Status = 400, Title = "address is required" });
            }
            try
            {
                var addressDelete = await _addressService.RemoveAddress(id.Value);
                return Ok(new ResponseModel
                {
                    Data = addressDelete
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseModel() { Status = 500, Title = ex.Message, IsSuccess = false }
                );
            }
        }
    }
}
