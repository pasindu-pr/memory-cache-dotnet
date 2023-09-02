using CachingInmemory.Models;
using CachingInmemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CachingInmemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult<List<Vehicle>> GetVehicles()
        {
            return _vehicleService.GetVehicles();
        }
    }
}
