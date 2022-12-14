using ProjectDomnet.Models;

namespace ProjectDomnet.WebAPI.ProjectDtos.VehicleModelDto
{
    public class CreateVehicleModel
    {
        public string ModelName { get; set; }
        public string ModelAbrv { get; set; }
        public int MakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
