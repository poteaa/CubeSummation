using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSumModel;

namespace CubeSumBusiness
{
    public interface ICubeSumManager
    {
        List<int> Process();
        List<Query> AllQueries();
    }
}
