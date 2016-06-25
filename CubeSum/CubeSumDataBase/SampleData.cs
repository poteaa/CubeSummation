using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSumDataBase
{
    public class SampleData : DropCreateDatabaseAlways<QueryEntitiesDB>
    {
        protected override void Seed(QueryEntitiesDB context)
        {
            var querivalues = new List<QueryValueDB>
            {
                new QueryValueDB {text="x"},
                new QueryValueDB {text="y"},
                new QueryValueDB {text="z"},
                new QueryValueDB {text="x1"},
                new QueryValueDB {text="y1"},
                new QueryValueDB {text="z1"},
                new QueryValueDB {text="x2"},
                new QueryValueDB {text="y2"},
                new QueryValueDB {text="z2"},
                new QueryValueDB {text="value"}
            };

            var queries = new List<QueryDB>
            {
                new QueryDB {query="UPDATE"},
                new QueryDB {query="QUERY"},
            };

            new List<QueValDB>
            {
                new QueValDB { Query = queries.Single(q => q.query == "UPDATE"), QueryValue = querivalues.Single(q => q.text == "x")},
                new QueValDB { Query = queries.Single(q => q.query == "UPDATE"), QueryValue = querivalues.Single(q => q.text == "y")},
                new QueValDB { Query = queries.Single(q => q.query == "UPDATE"), QueryValue = querivalues.Single(q => q.text == "z")},
                new QueValDB { Query = queries.Single(q => q.query == "UPDATE"), QueryValue = querivalues.Single(q => q.text == "value")},
                new QueValDB { Query = queries.Single(q => q.query == "QUERY"), QueryValue = querivalues.Single(q => q.text == "x1")},
                new QueValDB { Query = queries.Single(q => q.query == "QUERY"), QueryValue = querivalues.Single(q => q.text == "y1")},
                new QueValDB { Query = queries.Single(q => q.query == "QUERY"), QueryValue = querivalues.Single(q => q.text == "z1")},
                new QueValDB { Query = queries.Single(q => q.query == "QUERY"), QueryValue = querivalues.Single(q => q.text == "x2")},
                new QueValDB { Query = queries.Single(q => q.query == "QUERY"), QueryValue = querivalues.Single(q => q.text == "y2")},
                new QueValDB { Query = queries.Single(q => q.query == "QUERY"), QueryValue = querivalues.Single(q => q.text == "z2")}
            }.ForEach(qv => context.QueVal.Add(qv));
        }
    }
}
