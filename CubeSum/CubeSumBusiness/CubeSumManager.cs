using CubeSumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSumModel;

namespace CubeSumBusiness
{
    public class CubeSumManager : ICubeSumManager
    {
        private ExpressionValidator expVal;
        private string expression;

        public CubeSumManager()
        {
        }

        public CubeSumManager(string expression)
        {
            this.expression = expression;
        }

        public List<Query> AllQueries() 
        {
            BQuery bQuery = new BQuery();
            return bQuery.AllQueries();
        }

        public List<int> Process()
        {
            List<int> res = new List<int>();
            expVal = new ExpressionValidator(expression);
            string error = string.Empty;
            if (!expVal.IsValid(ref error))
            {
                throw new Exception(string.Format("Invalid expression: Error: {0}", error));
            }
            foreach (ExpressionData exp in expVal.Expressions)
            {
                Cube cube = new Cube(exp.size);
                foreach (Query query in exp.queries)
                {
                    if (query.query == "UPDATE")
                    {
                        Cell cell = cube.Matrix[int.Parse(query.parameters[0].value)-1, int.Parse(query.parameters[1].value)-1, 
                            int.Parse(query.parameters[2].value)-1];
                        cube.Update(cell, int.Parse(query.parameters[3].value));
                    }
                    else if (query.query == "QUERY")
                    {
                        Cell iniCell = cube.Matrix[int.Parse(query.parameters[0].value) - 1, int.Parse(query.parameters[1].value) - 1,
                            int.Parse(query.parameters[2].value) - 1];
                        Cell endCell = cube.Matrix[int.Parse(query.parameters[3].value) - 1, int.Parse(query.parameters[4].value) - 1,
                            int.Parse(query.parameters[5].value) - 1];
                        res.Add(cube.ExecuteQuery(iniCell, endCell));
                    }
                }
            }

            return res;

        }
    }
}
