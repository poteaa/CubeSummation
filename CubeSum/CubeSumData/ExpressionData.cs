using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CubeSumModel;

namespace CubeSumData
{
    public class ExpressionData
    {
        public int size { get; set; }
        public int operations { get; set; }
        public List<Query> queries { get; set; }

        public bool ValidateQueries()
        {
            bool valid = false;
            List<string> expsToMatch = GetAllExpressionsFromDB();
            foreach (Query query in queries)
            {
                valid = false;
                foreach (string expToMatch in expsToMatch)
                {
                    Regex reg = new Regex(expToMatch);
                    if (reg.IsMatch(query.ToString()))
                    {
                        valid = true;
                        break;
                    }
                }
                if (!valid)
                {
                    return false;
                }
            }

            return valid;
        }

        /// <summary>
        /// Gets all the valid expressions from the repository
        /// </summary>
        /// <returns>Expressions</returns>
        public List<string> GetAllExpressionsFromDB()
        {
            CubeSumData.IDataHelper data = new CubeSumData.DataHelper();
            return data.GetExpression();
        }
    }
}
