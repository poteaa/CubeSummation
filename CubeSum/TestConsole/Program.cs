using CubeSumBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CubeSumData;
using CubeSumModel;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BQuery query = new BQuery();
            List<Query> queries = query.AllQueryLabels();
        }
    }
}
