using CubeSumDataBase;
using CubeSumModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSumData
{
    public class DataHelper : IDataHelper
    {
        DBConnection database;

        public DataHelper()
        {
            database = DBConnection.GetInstance();
        }

        /// <summary>
        /// Gets the list of all valid expressions from the repository
        /// </summary>
        /// <returns></returns>
        public List<string> GetExpression()
        {
            return DataXMLWrapper.GetInstance().Expressions;
        }

        /// <summary>
        /// Returns the list of all valid expressions given a figure
        /// </summary>
        /// <param name="figure">Figure</param>
        /// <returns>List of valid expressions</returns>
        public List<string> GetExpression(string figure)
        {
            return DataXMLWrapper.GetInstance().GetExpression(figure);
        }

        public List<Query> AllQueries()
        {
            List<QueValDB> queVal = database.db.con.QueVal.ToList();
            List<Query> queries = QueryDTO.ConvertList(queVal);
            return queries;
        }

    }
}
