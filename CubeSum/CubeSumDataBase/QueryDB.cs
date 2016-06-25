using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CubeSumDataBase
{
    public class QueryDB
    {
        [Key]
        public int QueryId { get; set; }
        public string query { get; set; }
        public List<QueValDB> QueVal { get; set; }

        //public override string ToString()
        //{
        //    string toStr = query;
        //    foreach (QueryValue qv in parameters)
        //    {
        //        toStr = string.Format("{0} {1}", toStr, qv.value);
        //    }
        //    return toStr;
        //}
    }
}
