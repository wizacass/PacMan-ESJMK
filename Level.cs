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
        private int x, y;
        //private int _maxScore;

        public Level(string name)
        {
            _name = "levels/" + name + ".txt";

            _GetLevelInfo();
        }

        public void Draw()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(_board[i, j]);
                }
                Console.Write("\n");
            }
        }

        private void _GetLevelInfo()
        {
            string line;

            StreamReader data = new StreamReader(_name);
            line = data.ReadLine();
            string[] coords = line.Split();
            x = int.Parse(coords[0]);
            y = int.Parse(coords[1]);

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
            data.Close();
        }
    }
}
