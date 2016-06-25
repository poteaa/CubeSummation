using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CubeSumData
{
    public class DataXMLWrapper
    {
        public static DataXMLWrapper instance;
        private XDocument xdoc;
        private List<string> expressions;

        /// <summary>
        /// List of valid expressions
        /// </summary>
        public List<string> Expressions
        {
            get { return expressions; }
            set { expressions = value; }
        }
        
        /// <summary>
        /// Private constructor for singleton object
        /// </summary>
        private DataXMLWrapper()
        {
            xdoc = new XDocument();
            string xml = Properties.Resources.ValidExpression;
            xdoc = XDocument.Parse(xml);
            GetExpression();
        }

        /// <summary>
        /// Get instance of the singleton object
        /// </summary>
        /// <returns></returns>
        public static DataXMLWrapper GetInstance()
        {
            if (instance == null)
            {
                instance = new DataXMLWrapper();
            }

            return instance;
        }

        /// <summary>
        /// Fill the list of all valid expressions from the repository
        /// </summary>
        private void GetExpression()
        {
            expressions = xdoc.Root.Elements("exp").Select(elem => elem.Value).ToList();
        }

        /// <summary>
        /// Returns the list of all valid expressions given a figure
        /// </summary>
        /// <param name="figure">Figure</param>
        /// <returns>List of valid expressions</returns>
        public List<string> GetExpression(string figure)
        {
            throw new NotImplementedException();
        }
    }
}
