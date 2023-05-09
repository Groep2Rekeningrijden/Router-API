using Microsoft.AspNetCore.Mvc;
using Router_Api.DTOs;
using Router_Api.Models;
using Router_Api.Services;

namespace Router_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteApiController : ControllerBase
    {
        private readonly IRouterApiService _routerApiService;

        public RouteApiController(IRouterApiService routerApiService) 
        { 
            _routerApiService = routerApiService;
        }


        [HttpPut]
        public async Task SubmitRaw(RawInputDTO dto)
        {
            try
            {
                await _routerApiService.Write(dto);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<List<Coordinates>> GetCords()
        {
            try
            {
                return await _routerApiService.GetCoordinates();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<bool> GetStatus(GetStatusDTO dto)
        {
            return await _routerApiService.GetStatus(dto);
        }

      
    }
}