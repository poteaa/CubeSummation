using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CubeSumDataBase
{
    public class QueryValueDB
    {
        [Key]
        public int QueryValueId { get; set; }
        public string text { get; set; }
        public string value { get; set; }

        //public override string ToString()
        //{
        //    return string.Format(" {0} {1}", text, value);
        //}
    }
}
