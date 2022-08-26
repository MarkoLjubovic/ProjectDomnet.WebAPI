using System.ComponentModel.DataAnnotations;

namespace ProjectDomnet.Models
{
    public class VehicleMake
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MakeAbrv { get; set; }
    }
}
