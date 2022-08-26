using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Common
{
    public class PagingSorting
    {
        public string SOrder { get; set; }
        public int? PIndex { get; set; }
        public string PFilter { get; set; }
        public int PSize { get; set; }
        public int NumPages { get; set; }
    }
}
