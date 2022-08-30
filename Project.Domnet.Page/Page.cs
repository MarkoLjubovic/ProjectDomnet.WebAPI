using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Common
{
    public class Page:IFiltering, IPaging, ISorting
    {
        public string SortOrder { get; set; } = "";
        public int? PgIndex { get; set; } = 0;
        public string PgFilter { get; set; } = "";
        public int PgSize { get; set; } = 4;
        public int NumPages { get; set; } = 0;
    }
}
