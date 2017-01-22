using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_DeepMind
{
    class Level
    {
        private string _name;
        private char[,] _board;
        //private int _maxScore;

        public Level(string name)
        {
            _name = "levels/" + name + ".txt";

            _GetLevelInfo();
        }



        private void _GetLevelInfo()
        {
            /*
                if(File.Exists(_name))
                {
                    TextReader data = File.OpenText(_name);
                    string levelSize = data.ReadLine();
                    string[] coords = levelSize.Split();
                    int x = int.Parse(coords[0]);
                    int y = int.Parse(coords[1]);
                    //Console.WriteLine(x + "\t" + y);

                    _board = new char[x, y];

                    string line = File.ReadAllText(_name);
                    Console.WriteLine("\n" + line + "\n");


                }
                else
                {
                    Console.WriteLine("Error! Level file doesn't exist!");
                }
            */
            string line;

            StreamReader data = new StreamReader(_name);
            line = data.ReadLine();
            string[] coords = line.Split();
            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);
            //Console.WriteLine(x + "\t" + y);

            _board = new char[x, y];

            for (int i = 0; i < x; i++)
            {
                int counter = 0;
                line = data.ReadLine();
                foreach (char c in line)
                {
                    _board[i, counter] = c;
                    counter++;
                }
            }

            //Debug print board
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(_board[i, j]);
                }
                Console.Write("\n");
            }

        }
    }
}
