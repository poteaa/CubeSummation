using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSumModel
{
    public class Query
    {
        public int id { get; set; }
        public string query { get; set; }
        public virtual List<QueryValue> parameters { get; set; }

        public override string ToString()
        {
            string toStr = query;
            foreach (QueryValue qv in parameters)
            {
                toStr = string.Format("{0} {1}", toStr, qv.value);
            }
            return toStr;
        }
    }
}
