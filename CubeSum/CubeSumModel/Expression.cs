using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CubeSumModel;

namespace CubeSumModel
{
    public class Expression
    {
        public int size { get; set; }
        public int operations { get; set; }
        public List<Query> queries { get; set; }

    }
}
