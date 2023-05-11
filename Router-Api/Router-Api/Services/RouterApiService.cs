using Microsoft.EntityFrameworkCore;
using Router_Api.Data;
using Router_Api.DTOs;
using Router_Api.Models;

namespace Router_Api.Services
{
    public class RouterApiService : IRouterApiService
    {
        private readonly DataContext _dataContext;

        public RouterApiService(DataContext context)
        {
            _dataContext = context;
        }

        public Task<List<Coordinates>> GetCoordinates()
        {
            return _dataContext.Coordinates.ToListAsync();
        }

        public async Task Write(RawInputDTO dto)
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            string vehicleId = dto.VehicleId;

            foreach (CoordinatesDTO cord in dto.Coordinates)
            {
                coordinates.Add(new Coordinates
                {
                    VehicleId = vehicleId,
                    Lat = cord.Lat,
                    Long = cord.Lon,
                    Time = cord.Time
                });
            }

            try
            {
                await _dataContext.Coordinates.AddRangeAsync(coordinates);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> GetStatus(GetStatusDTO dto)
        {
            bool statusComplete = Convert.ToBoolean(dto.Status);

            if (!statusComplete) return statusComplete;

            List<Coordinates> coordinates = await _dataContext.Coordinates.Where(x => x.VehicleId == dto.VehicleId).ToListAsync();

            //code voor het verzenden van alle coordinaten die bij vehicle ID horen

            //verwijderen van alle coordinaten na het verzenden
            _dataContext.RemoveRange(coordinates);
            await _dataContext.SaveChangesAsync();
            return statusComplete;

        }

        public async Task<List<LatLongDto>> GetCordsByVehicle(string id, DateTime? start, DateTime? end)
        {
            List<Coordinates> cords = await _dataContext.Coordinates.Where(x => x.VehicleId == id).ToListAsync();
            cords = cords.OrderBy(x => x.Time).ToList();
            List<LatLongDto> latlong = new List<LatLongDto>();  

            foreach (Coordinates cord in cords)
            {
                latlong.Add(new LatLongDto
                {
                    Lat = cord.Lat,
                    Long = cord.Long
                });
            }
            return latlong;
        }

        public async Task<List<string>> GetAllVehicleIDs()
        {
            return _dataContext.Coordinates.Select(x => x.VehicleId).Distinct().ToList();
        }

    }
}
