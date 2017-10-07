using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task2
{
    /// <summary>
    /// Network class
    /// </summary>
    class Network
    {
        private bool[,] adjacencyMatrix;
        private Computer[] computers;

        /// <summary>
        /// Load network info from file
        /// </summary>
        /// <param name="path"></param>
        public Network(String path)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    Int32 size = int.Parse(file.ReadLine());

                    computers = LoadComputers(file, size);
                    adjacencyMatrix = LoadMatrix(file, size);
                }
            }
            catch
            {

            }
        }

        public void Plague()
        {
            List<Computer> toInfect = new List<Computer>();

            for (Int32 i = 0; i < computers.Length; i++)
            {
                if (computers[i].IsInfected)
                {
                    for (int j = 0; j < adjacencyMatrix.GetLength(0); j++)
                    {
                        if (adjacencyMatrix[i, j] && !computers[j].IsInfected)
                        {
                            if (!toInfect.Contains(computers[j]))
                            {
                                toInfect.Add(computers[j]);
                            }
                        }
                    }
                }
            }

            foreach (var a in toInfect)
            {
                a.TryToInfect();
            }
        }
        /// <summary>
        /// Returns current state of network
        /// </summary>
        /// <returns></returns>
        public String State()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < computers.Length; i++)
            {
                sb.Append(i + 1);
                sb.Append(") ");
                sb.Append(computers[i].OS);

                if (computers[i].IsInfected)
                {
                    sb.Append(" (Infected)");
                }
                sb.Append("\n");
            }
            sb.Append("\n");
            return sb.ToString();
        }
        /// <summary>
        /// Returns adjacency matrix of network
        /// </summary>
        /// <returns></returns>
        public String Graph()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" ");
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                sb.Append("    ");
                sb.Append(i + 1);
            }

            sb.Append("\n\n");

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                sb.Append(i + 1);
                sb.Append("    ");

                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    sb.Append(adjacencyMatrix[i, j] ? 1 : 0);
                    sb.Append("    ");
                }
                sb.Append("\n");
            }

            sb.Append("\n");
            return sb.ToString();
        }

        private static Computer[] LoadComputers(StreamReader file, Int32 size)
        {
            Computer[] computers = new Computer[size];
            try
            {
                for (Int32 i = 0; i < size; i++)
                {
                    computers[i] = new Computer(file.ReadLine());
                }

                file.ReadLine();

                String infect = file.ReadLine();
                String[] infectList = infect.Split(' ');
                for (Int32 i = 0; i < infectList.Length; i++)
                {
                   Int32 enemy = Int32.Parse(infectList[i]) - 1;
                    computers[enemy].Infect();
                }

                file.ReadLine();
            }
            catch
            {

            }

            return computers;
        }

        private static bool[,] LoadMatrix(StreamReader file,Int32 size)
        {
            bool[,] adjacencyMatrix = new bool[size, size];
            try
            {
                for (Int32 i = 0; i < size; i++)
                {
                    for (Int32 j = 0; j < size; j++)
                    {
                        adjacencyMatrix[i, j] = false;
                    }
                }

                Int32 connections = Int32.Parse(file.ReadLine());
                for (Int32 i = 0; i < connections; i++)
                {
                    String connect = file.ReadLine();
                    String[] connectionPoint = connect.Split(' ');
                    Int32 x = Int32.Parse(connectionPoint[0]) - 1;
                    Int32 y = Int32.Parse(connectionPoint[1]) - 1;

                    adjacencyMatrix[x, y] = true;
                    adjacencyMatrix[y, x] = true;
                }

                file.ReadLine();
            }
            catch
            {

            }


            return adjacencyMatrix;
        }
    }
}
