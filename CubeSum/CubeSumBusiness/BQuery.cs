using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSumData;
using CubeSumModel;

namespace CubeSumBusiness
{
    internal class BQuery
    {
        public List<Query> AllQueries()
        {
            DataHelper helper = new CubeSumData.DataHelper();
            List<Query> queval = helper.AllQueries();
            return queval;
        }
    }
}
