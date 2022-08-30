using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomnet.Common
{
    public interface IPaging
    {
        public int? PgIndex { get; set; }
        public int PgSize { get; set; }
        public int NumPages { get; set; }
    }
}
