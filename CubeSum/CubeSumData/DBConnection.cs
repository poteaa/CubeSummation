using CubeSumDataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CubeSumData
{
    public class DBConnection
    {
        public static DBConnection instance;
        public Initializer db;

        private DBConnection()
        {
            db = new Initializer();
        }

        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }

            return instance;
        }
    }
}
