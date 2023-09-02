using CachingInmemory.Models;

namespace CachingInmemory.Services
{
    public interface IVehicleService
    {
        public List<Vehicle> GetVehicles();
    }
}
