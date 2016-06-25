using CubeSumDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CubeSumModel;

namespace CubeSumData
{
    public static class QueryDTO
    {
        public static Query Convert(IList<QueValDB> qvDB)
        {
            Query query = new Query();
            query.query = qvDB[0].Query.query;
            var a = from qv in qvDB
                    select new QueryValue
                    {
                         text = qv.QueryValue.text,
                         value = qv.QueryValue.value
                    };
            query.parameters = a.ToList();
            return query;
        }

        public static List<Query> ConvertList(IList<QueValDB> qvDB)
        {
            List<Query> queries = new List<Query>();
            var filteredQueVal = qvDB.GroupBy(q => q.Query.query).Select(q => q.First());
            foreach (QueValDB queVal in filteredQueVal)
            {
                List<QueValDB> qval = qvDB.Where(q => q.Query.query == queVal.Query.query).ToList();
                queries.Add(Convert(qval));
            }

            return queries;
        }
    }
}
