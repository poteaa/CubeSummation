using System;
using System.Collections.Generic;
using CubeSumBusiness;
using CubeSumModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CubeSumBusinessTest
    {
        [TestMethod]
        public void GetQueries()
        {
            CubeSumManager sumManager = new CubeSumManager();
            List<Query> queries = sumManager.AllQueries();
            Assert.IsTrue(queries != null && queries.Count > 0);
        }
    }
}
