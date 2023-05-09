using Router_Api.DTOs;
using Router_Api.Models;

namespace Router_Api.Services
{
    public interface IRouterApiService
    {
        public Task Write(RawInputDTO dto);

        public Task<List<Coordinates>> GetCoordinates();

        public Task<bool> GetStatus(GetStatusDTO dto);
    }
}
