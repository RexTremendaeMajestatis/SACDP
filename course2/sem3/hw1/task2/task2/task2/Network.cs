using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Network class
    /// </summary>
    public sealed class Network
    {
        private readonly bool[,] AdjacencyMatrix;
        private readonly Computer[] Computers;

        /// <summary>
        /// Network constructor
        /// </summary>
        public Network(string path, ICustomRandom randomizer)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    int size = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());

                    Computers = LoadComputers(file, size, randomizer);
                    AdjacencyMatrix = LoadMatrix(file, size);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(message: "Invalid file path", innerException: e); 
            }
        }

        /// <summary>
        /// Returns current state of network
        /// </summary>
        public string State()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Computers.Length; i++)
            {
                sb.Append(i + 1);
                sb.Append(") ");
                sb.Append(Computers[i].Os);

                if (Computers[i].IsInfected)
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
        public string Graph()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" ");
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                sb.Append("    ");
                sb.Append(i + 1);
            }
            sb.Append("\n\n");

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                sb.Append(i + 1);
                sb.Append("    ");

                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {
                    sb.Append(AdjacencyMatrix[i, j] ? 1 : 0);
                    sb.Append("    ");
                }
                sb.Append("\n");
            }
            sb.Append("\n");

            return sb.ToString();
        }

        /// <summary>
        /// Start plague game
        /// </summary>
        public string StartGame()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(State());
            sb.Append(Graph());
            bool temp = true;

            while (CountUninfected() != 0 && temp)
            {
                temp = Plague();
                sb.Append(State());
                sb.Append(Graph());
            }

            return temp ? sb.ToString() : "";
        }

        /// <summary>
        /// Start one cycle of game
        /// </summary>
        public void StartOneCycleOfGame() => Plague();

        private int CountUninfected()
        {
            int i = 0;
            foreach (Computer t in Computers)
            {
                if (!t.IsInfected)
                {
                    i++;
                }
            }
            return i;
        }

        private static Computer[] LoadComputers(StreamReader file, int size, ICustomRandom randomizer)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            var computers = new Computer[size];

            for (int i = 0; i < size; i++)
            {
                computers[i] = new Computer(file.ReadLine(), randomizer);
            }
            file.ReadLine();

            string infect = file.ReadLine();
            if (infect != null)
            {
                string[] infectList = infect.Split(' ');
                for (int i = 0; i < infectList.Length; i++)
                {
                    int enemy = int.Parse(infectList[i]) - 1;
                    computers[enemy].Infect();
                }
            }
            file.ReadLine();

            return computers;
        }

        private static bool[,] LoadMatrix(StreamReader file, int size)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            var adjacencyMatrix = new bool[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    adjacencyMatrix[i, j] = false;
                }
            }

            int connections = int.Parse(file.ReadLine() ?? throw new InvalidOperationException());

            for (int i = 0; i < connections; i++)
            {
                string connect = file.ReadLine();
                if (connect != null)
                {
                    string[] connectionPoint = connect.Split(' ');
                    int x = int.Parse(connectionPoint[0]) - 1;
                    int y = int.Parse(connectionPoint[1]) - 1;

                    adjacencyMatrix[x, y] = true;
                    adjacencyMatrix[y, x] = true;
                }
            }
            file.ReadLine();

            return adjacencyMatrix;
        }

        private bool Plague()
        {
            var toInfect = new HashSet<Computer>();

            for (int i = 0; i < Computers.Length; i++)
            {
                if (Computers[i].IsInfected)
                {
                    for (int j = 0; j < AdjacencyMatrix.GetLength(0); j++)
                    {
                        if (AdjacencyMatrix[i, j] && !Computers[j].IsInfected)
                        {
                            toInfect.Add(Computers[j]);
                        }
                    }
                }
            }

            foreach (var a in toInfect)
            {
                a.TryToInfect();
            }

            return toInfect.Count != 0;
        }
    }
}
