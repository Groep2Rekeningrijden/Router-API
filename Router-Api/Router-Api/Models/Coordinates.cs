namespace Router_Api.Models
{
    public class Coordinates
    {
        public Guid Id { get; set; }

        public string VehicleId { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public DateTime Time { get; set; }

        public Coordinates() 
        { 
            
        }    


    }
}
