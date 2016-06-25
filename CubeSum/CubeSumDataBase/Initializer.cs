using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CubeSumDataBase
{
    public class Initializer
    {
        public QueryEntitiesDB con;

        public Initializer()
        {
            Database.SetInitializer(new SampleData());
            con = new QueryEntitiesDB();
        }
    }
}
