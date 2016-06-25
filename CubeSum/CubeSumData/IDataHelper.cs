﻿using CubeSumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSumData
{
    public interface IDataHelper
    {
        /// <summary>
        /// Gets the list of all valid expressions from the repository
        /// </summary>
        /// <returns></returns>
        List<string> GetExpression();

        /// <summary>
        /// Returns the list of all valid expressions given a figure
        /// </summary>
        /// <param name="figure">Figure</param>
        /// <returns>List of valid expressions</returns>
        List<string> GetExpression(string figure);

        List<Query> AllQueries();
    }
}