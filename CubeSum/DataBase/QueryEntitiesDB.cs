using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase
{
    public class QueryEntitiesDB : DbContext
    {
        public DbSet<QueryDB> Query { get; set; }
        public DbSet<QueryValueDB> QueryValue { get; set; }
        public DbSet<QueValDB> QueVal { get; set; }
    }
}
