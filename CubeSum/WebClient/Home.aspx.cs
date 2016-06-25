using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CubeSumModel;

namespace WebClient
{
    public partial class Home : System.Web.UI.Page
    {
        XDocument xdoc;

        protected void Page_Render(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Hola');</script>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!Page.IsPostBack || Session["scriptQuery"] == null)
            {
                LoadQueries();
            }
            if (Session["scriptQuery"] != null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", Session["scriptQuery"].ToString(), true);
            }
        }

        private void LoadQueries()
        {
            CubeSumBusiness.CubeSumManager cubeSumManager = new CubeSumBusiness.CubeSumManager();
            List<Query> queries = cubeSumManager.AllQueries();

            StringBuilder script = new StringBuilder();
            script.Append("availableQueries = [];");

            for (int i = 0; i < queries.Count; i++)
            {
                Query query = queries[i];
                string objQuery = "objQuery" + i; ;
                script.AppendFormat("var {0} = new Query('{1}');", objQuery, query.query);
                foreach (QueryValue queryValue in query.parameters)
                {
                    script.AppendFormat("{0}.values.push(new QueryValue('{1}', ''));", objQuery, queryValue.text);
                }
                script.AppendFormat("availableQueries.push({0});", objQuery);
            }

            Session["scriptQuery"] = script;
            ClientScript.RegisterStartupScript(GetType(), "Javascript", script.ToString(), true);
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            try
            {
                GenerateExpression();
                CubeSumBusiness.CubeSumManager csm = new CubeSumBusiness.CubeSumManager(xdoc.ToString());
                List<int> res = csm.Process();
                string response = string.Empty;
                foreach (int value in res)
                {
                    response = string.Format("{0} {1}\n", response, value);
                }
                taOutput.Text = response;
            }
            catch (Exception ex)
            {

                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

        }

        private void GenerateExpression()
        {
            List<string> commands = taInput.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int pos = 0;
            int testCases = int.Parse(commands[pos++]);
            xdoc = new XDocument();
            XElement xElExpressions = new XElement("EXPRESSIONS");
            xdoc.Add(xElExpressions);
            xElExpressions.SetAttributeValue("testcases", testCases);
            for (int i = 0; i < testCases; i++)
            {
                XElement xElMatrix = new XElement("MATRIX");
                xElExpressions.Add(xElMatrix);
                string[] values = commands[pos++].Split(' ');
                int operations = int.Parse(values[1]);
                xElMatrix.SetAttributeValue("SIZE", values[0]);
                xElMatrix.SetAttributeValue("OPERATIONS", values[1]);

                for (int j = 0; j < operations; j++)
                {
                    string[] queryvalues = commands[pos++].Split(' ');
                    XElement xElQuery = new XElement("QUERY");
                    xElMatrix.Add(xElQuery);
                    XElement xElQueryCommand = new XElement("COMMAND");
                    xElQueryCommand.SetValue(queryvalues[0]);
                    xElQuery.Add(xElQueryCommand);
                    for (int k = 1; k < queryvalues.Count(); k++)
                    {
                        XElement xElQueryValue = new XElement("QUERYVALUE");
                        XElement xElText = new XElement("TEXT");
                        xElText.SetValue(string.Empty);
                        XElement xElValue = new XElement("VALUE");
                        xElValue.SetValue(queryvalues[k]);
                        xElQueryValue.Add(xElText);
                        xElQueryValue.Add(xElValue);
                        xElQuery.Add(xElQueryValue);
                    }
                }
            }
        }
    }
}