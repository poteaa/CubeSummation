using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeSumModel
{
    /// <summary>
    /// Class to create a Cell
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// x location of the point
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// y location of the cell
        /// </summary>
        public int y { get; set; }

        /// <summary>
        /// z location of the cell
        /// </summary>
        public int z { get; set; }

        /// <summary>
        /// Value of the cell
        /// </summary>
        public int value { get; set; }

        /// <summary>
        /// Value of the cell
        /// </summary>
        public bool readed { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Cell()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x location of the cell</param>
        /// <param name="y">y location of the cell</param
        /// <param name="z">z location of the cell</param>
        public Cell(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            readed = false;
        }
        
        // Returns the value of the cell
        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
