namespace Router_Api.DTOs
{
    public class RawInputDTO
    {

        public string VehicleId { get; set; }

        public List<CoordinatesDTO> Coordinates { get; set; } 

        public RawInputDTO() 
        { 
            Coordinates = new List<CoordinatesDTO>();
        }
    }
}
