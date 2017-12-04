using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    public class RobotGraph
    {
        private int VerticesAmount;
        private bool[,] Matrix;
        private bool[] Positions;
        private bool[] Visited;

        public RobotGraph(string path)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    this.VerticesAmount = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());
                    file.ReadLine();

                    this.Visited = new bool[VerticesAmount];

                    for (int i = 0; i < VerticesAmount; i++)
                    {
                        Visited[i] = false;
                    }

                    this.Positions = LoadPositions(file, VerticesAmount);
                    this.Matrix = LoadMatrix(file, VerticesAmount);
                }
            }
            catch (FileNotFoundException e)
            {

            }
        }

        private static bool[] LoadPositions(StreamReader file, int verticesAmount)
        {
            int robotsAmount = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());
            file.ReadLine();

            var positions = new bool[verticesAmount];

            for (int i = 0; i < verticesAmount; i++)
            {
                positions[i] = false;
            }

            for (int i = 0; i < robotsAmount; i++)
            {
                int temp = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());
                positions[temp - 1] = true;
            }

            file.ReadLine();

            return positions;
        }

        private static bool[,] LoadMatrix(StreamReader file, int verticesAmount)
        {
            var matrix = new bool[verticesAmount, verticesAmount];

            for (int i = 0; i < verticesAmount; i++)
            {
                for (int j = 0; j < verticesAmount; j++)
                {
                    matrix[i, j] = false;
                }
            }

            int connectionsAmount = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());
            file.ReadLine();

            for (int i = 0; i < connectionsAmount; i++)
            {
                string connect = file.ReadLine();

                if (connect != null)
                {
                    string[] connectionPoint = connect.Split(' ');
                    int x = int.Parse(connectionPoint[0]) - 1;
                    int y = int.Parse(connectionPoint[1]) - 1;

                    matrix[x, y] = true;
                    matrix[y, x] = true;
                } 
            }

            return matrix;
        }
    }
}
