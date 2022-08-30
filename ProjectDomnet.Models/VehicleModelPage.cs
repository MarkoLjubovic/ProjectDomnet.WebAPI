using ProjectDomnet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Models
{
    public class VehicleModelPage
    {
        public Paging paging { get; set; }
        public List<VehicleModel> VehicleModelsModel;
    }
}
