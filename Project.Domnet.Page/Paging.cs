using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Common
{
    public class Paging
    {
        public int? PgIndex { get; set; } = 0;
        public int PgSize { get; set; } = 5;
        public int NumOfPages { get; set; } = 0;
    }
}
