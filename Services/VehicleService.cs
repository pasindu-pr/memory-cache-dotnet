using CachingInmemory.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CachingInmemory.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMemoryCache _memoryCache;
        public string cacheKey = "vehicles";

        public VehicleService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles;            

            if(!_memoryCache.TryGetValue(cacheKey, out vehicles))
            {
                vehicles = GetValuesFromDbAsync().Result;
     
                _memoryCache.Set(cacheKey, vehicles,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
            }            
            return vehicles;            
        }

        private Task<List<Vehicle>> GetValuesFromDbAsync ()
        {

            List<Vehicle> vehicles = new List<Vehicle>
            {
            new Vehicle { Id = 1, Name = "Car" },
            new Vehicle { Id = 2, Name = "Truck" },
            new Vehicle { Id = 3, Name = "Motorcycle" }
            };

            Task<List<Vehicle>> VehiclesTask = Task<List<Vehicle>>.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return vehicles;
            });

            return VehiclesTask;

        }
    }
}
