using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDomnet.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string ModelAbrv { get; set; }

        [ForeignKey("MakeId")]
        public int MakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
