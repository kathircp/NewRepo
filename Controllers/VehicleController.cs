using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.WebApiClasses;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicle _vehicle;
        public VehicleController(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var result = await _vehicle.GetProductByIdAsync(id);
            return Ok(result);
        }
    }
}
