using System;
using System.IO;

namespace Task3
{
    /// <summary>
    /// Class that realize homework algorithm
    /// </summary>
    public class RobotGraph
    {
        private int VerticesAmount;
        private bool[,] Matrix;
        private bool[] Positions;
        private bool[] Visited;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotGraph"> class
        /// </summary>
        /// <param name="path">Path to file</param>
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Check ability of crash after teleportation
        /// </summary>
        /// <returns>True if robots crash after teleportation</returns>
        public bool CheckCrash()
        {
            for (int i = 0; i < VerticesAmount; i++)
            {
                if (!Visited[i] && Positions[i])
                {
                    int numberConected = 0;
                    FindNeighbours(i, ref numberConected);
                    if (numberConected == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Load robots positions from file
        /// </summary>
        /// <param name="file">StreamReader example</param>
        /// <param name="verticesAmount">Amount of vertices</param>
        /// <returns>0-1 vector of positions</returns>
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

        /// <summary>
        /// Load adjacency matrix from file
        /// </summary>
        /// <param name="file">StreamReader example</param>
        /// <param name="verticesAmount">Amount if vertices</param>
        /// <returns>Boolean massive</returns>
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

        /// <summary>
        /// Finds connected robots
        /// </summary>
        /// <param name="vertex">Vertex number</param>
        /// <param name="connected">Amount of connected robots</param>
        private void FindNeighbours(int vertex, ref int connected)
        {
            if (Visited[vertex])
            {
                return;
            }

            if (Positions[vertex])
            {
                connected++;
            }

            Visited[vertex] = true;

            for (int i = 0; i < VerticesAmount; i++)
            {
                if (Matrix[vertex, i])
                {
                    for (int j = 0; j < VerticesAmount; j++)
                    {
                        if (Matrix[i, j])
                        {
                            FindNeighbours(j, ref connected);
                        }
                    }
                }
            }
        }
    }
}