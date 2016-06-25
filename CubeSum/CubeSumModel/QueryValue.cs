using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSumModel
{
    public class QueryValue
    {
        public int id { get; set; }
        public string text { get; set; }
        public string value { get; set; }

        public override string ToString()
        {
            return string.Format(" {0} {1}", text, value);
        }

    }
}
