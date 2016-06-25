using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataBase
{
    public class DBConnection
    {
        public static DBConnection instance;
        QueryEntitiesDB con;

        private DBConnection()
        {
            Database.SetInitializer(new SampleDataB());
            con = new QueryEntitiesDB();
        }

        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DataXMLWrapper();
            }

            return instance;
        }
    }
}
