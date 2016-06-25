using CubeSumData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using CubeSumModel;

namespace CubeSumBusiness
{
    class ExpressionValidator
    {
        private XDocument xdoc;
        private List<ExpressionData> expressions;
        ValidValues validValues;

        private struct ValidValues
        {
            public long minT;
            public long maxT;
            public long minN;
            public long maxN;
            public long minM;
            public long maxM;
            public long minW;
            public long maxW;
        }



        public List<ExpressionData> Expressions
        {
            get { return expressions; }
            set { expressions = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expression">Expression</param>
        public ExpressionValidator(string expression)
        {
            xdoc = XDocument.Parse(expression);
            InitializeStruct();
            expressions = CreateExpressions();
        }

        private void InitializeStruct()
        {
            validValues = new ValidValues();
            validValues.minT = Convert.ToInt64(ConfigurationManager.AppSettings["minT"]);
            validValues.maxT = Convert.ToInt64(ConfigurationManager.AppSettings["maxT"]);
            validValues.minN = Convert.ToInt64(ConfigurationManager.AppSettings["minN"]);
            validValues.maxN = Convert.ToInt64(ConfigurationManager.AppSettings["maxN"]);
            validValues.minM = Convert.ToInt64(ConfigurationManager.AppSettings["minM"]);
            validValues.maxM = Convert.ToInt64(ConfigurationManager.AppSettings["maxM"]);
            validValues.minW = Convert.ToInt64(ConfigurationManager.AppSettings["minW"]);
            validValues.maxW = Convert.ToInt64(ConfigurationManager.AppSettings["maxW"]);
        }

        /// <summary>
        /// Validates expression
        /// </summary>
        /// <returns>True if the expression is valid</returns>
        public bool IsValid(ref string error)
        {
            bool valid = false;
            long testcases = Convert.ToInt16(xdoc.Root.Attribute("testcases").Value);
            long matrixes = xdoc.Root.Elements("MATRIX").Count();

            bool invalidMatrixes = xdoc.Root.Elements("MATRIX").Where(
                x => Convert.ToInt64(x.Attribute("SIZE").Value) < validValues.minN
                    || Convert.ToInt64(x.Attribute("SIZE").Value) > validValues.maxN).Count() != 0;


            bool invalidNumOper = xdoc.Root.Elements("MATRIX").Where(
                x => Convert.ToInt64(x.Attribute("OPERATIONS").Value) < validValues.minM
                    || Convert.ToInt64(x.Attribute("OPERATIONS").Value) > validValues.maxM).Count() != 0;

            bool invalidValue = xdoc.Root.Elements("MATRIX").Elements("QUERY").Elements("QUERYVALUE").Elements("VALUE").Where(
                x => Convert.ToInt64(x.Value) < validValues.minT
                    || Convert.ToInt64(x.Value) > validValues.maxT).Count() != 0;

            if (testcases < validValues.minT || testcases > validValues.maxT)
            {
                error = string.Format("Testcases must be between {0} and {1}", validValues.minT, validValues.maxT);
            }
            else if (matrixes < validValues.minN || testcases > validValues.maxN || invalidMatrixes)
            {
                error = string.Format("Matrix size must be between {0} and {1}", validValues.minN, validValues.maxN);
            }
            else if (testcases != matrixes)
            {
                error = "Test cases number different from given test cases";
            }
            else if (expressions.Count() != ValidExpressions().Count() || invalidNumOper)
            {
                error = string.Format("Testcases must be between {0} and {1}", validValues.minM, validValues.maxM);
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        private List<ExpressionData> CreateExpressions()
        {
            List<ExpressionData> retExp = new List<ExpressionData>();
            var exps = from elem in xdoc.Root.Elements("MATRIX")
                       where elem.Attribute("OPERATIONS").Value.Equals(elem.Elements("QUERY").Count().ToString())
                       select new ExpressionData
                       {
                           size = Convert.ToInt32(elem.Attribute("SIZE").Value),
                           operations = Convert.ToInt32(elem.Attribute("OPERATIONS").Value),
                           queries = (List<Query>)(from query in elem.Elements("QUERY")
                                     select new Query 
                                     {
                                         query = query.Element("COMMAND").Value,
                                         parameters = (List<QueryValue>)(from subquery in query.Elements("QUERYVALUE")
                                                                             select new QueryValue
                                                                             {
                                                                                 text = subquery.Element("TEXT").Value,
                                                                                 value = subquery.Element("VALUE").Value,
                                                                             }
                                                                             ).ToList()
                                     }).ToList()
                       };

            if (exps.Count() > 0)
            {
                retExp = (List<ExpressionData>)exps.ToList();
            }

            return retExp;
        }

        private List<ExpressionData> ValidExpressions()
        {
            List<ExpressionData> retExp = new List<ExpressionData>();
            var exps = from exp in expressions
                       where exp.ValidateQueries()
                       select exp;

            if (exps.Count() > 0)
            {
                retExp = (List<ExpressionData>)exps.ToList();
            }

            return retExp;
        }

    }
}
