using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task2
{
    class Network
    {
        private bool[,] adjacencyMatrix;
        private Computer[] computers;

        public Network(String path)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    Int32 size = int.Parse(file.ReadLine());

                    computers = LoadComputers(file, size);
                    adjacencyMatrix = loadMatrix(file, size);
                }
            }
            catch
            {

            }
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
                    int enemy = Int32.Parse(infectList[i]) - 1;
                    computers[enemy].Infect();
                }

                file.ReadLine();
            }
            catch
            {

            }

            return computers;
        }

        private static bool[,] loadMatrix(StreamReader file, int size)
        {
            bool[,] matrix = new bool[size, size];
            try
            {
                for (Int32 i = 0; i < size; i++)
                {
                    for (Int32 j = 0; j < size; j++)
                    {
                        matrix[i, j] = false;
                    }
                }

                Int32 connections = Int32.Parse(file.ReadLine());
                for (Int32 i = 0; i < connections; i++)
                {
                    String connect = file.ReadLine();
                    String[] connectionPoint = connect.Split(' ');
                    Int32 x = Int32.Parse(connectionPoint[0]) - 1;
                    Int32 y = Int32.Parse(connectionPoint[1]) - 1;

                    matrix[x, y] = true;
                    matrix[y, x] = true;
                }

                file.ReadLine();
            }
            catch
            {

            }


            return matrix;
        }
    }
}
