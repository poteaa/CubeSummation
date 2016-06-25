using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSumModel
{
    public class Cube
    {
        private int width;
        private int height;
        private int length;

        private Cell[, ,] matrix;

        public Cell[, ,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        } 

        public Cube(int N)
        {
            this.width = N;
            this.height = N;
            this.length = N;

            InitializeValues();
        }

        /// <summary>
        /// Initializes the cube cells
        /// </summary>
        private void InitializeValues()
        {
            this.matrix = new Cell[width, height, length];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < length; k++)
                    {
                        Cell cell = new Cell(i, j, k) { value = 0 };
                        matrix[i, j, k] = cell;
                    }
                }
            }
        }

        public int ExecuteQuery(Cell initial, Cell final)
        {
            InitializeCellAsNotRead();
            return Query(initial, final);
        }

        private void InitializeCellAsNotRead()
        {
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < length; k++)
                    {
                        matrix[i, j, k].readed = false;
                    }
                }
            }
        }

        public int Query(Cell initial, Cell final)
        {
            if (initial == null || initial.readed || initial.x > final.x || initial.y > final.y || initial.z > final.z)
            {
                return 0;
            }
            else if (initial == final)
            {
                if (!final.readed)
                {
                    final.readed = true;
                    return final.value;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                Cell cellx;
                if (initial.x + 1 < width)
                {
                    cellx = Matrix[initial.x + 1, initial.y, initial.z];
                }
                else
                {
                    cellx = null;
                }
                Cell celly;
                if (initial.y + 1 < height)
                {
                    celly = Matrix[initial.x, initial.y + 1, initial.z];
                }
                else
                {
                    celly = null;
                }
                Cell cellz;

                if (initial.z + 1 < length)
                {
                    cellz = Matrix[initial.x, initial.y, initial.z + 1];
                }
                else 
                {
                    cellz = null;
                }

                initial.readed = true;
                return initial.value + Query(cellx, final) + Query(celly, final) + Query(cellz, final); 
            }

        }

        public void Update(Cell cell, int value)
        {
            matrix[cell.x, cell.y, cell.z].value = value;
        }
    }
}
