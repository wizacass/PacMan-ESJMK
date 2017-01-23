using System;
using System.IO;

namespace Pacman_DeepMind
{
    class Level
    {
        public int pX, pY;

        private string _name;
        private char[,] _board;
        private int x, y;
        private int _maxScore;

        public Level(string name)
        {
            _name = "levels/" + name + ".txt";

            _GetLevelInfo();
        }

        public int GetScore()
        {
            return _maxScore;
        }

        public void SetPac(int x, int y)
        {
            _board[x, y] = 'C';
        }

        public int CheckScore(int x, int y, int score)
        {
            if (_board[x, y] == '+')
            {
                score++;
            }
            return score;
        }

        public void ClearTile(int x, int y)
        {
            if (_board[x - 1, y] == 'C')
            {
                _board[x - 1, y] = ' ';
            }
            if (_board[x + 1, y] == 'C')
            {
                _board[x + 1, y] = ' ';
            }
            if (_board[x, y - 1] == 'C')
            {
                _board[x, y - 1] = ' ';
            }
            if (_board[x, y + 1] == 'C')
            {
                _board[x, y + 1] = ' ';
            }
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

        public DIRECTION Check(int x, int y, DIRECTION dir)
        {
            switch (dir)
            {
                case DIRECTION.UP:
                    if (_board[x - 1, y] == '#')
                        return DIRECTION.STOP;
                    else
                        return DIRECTION.UP;
                case DIRECTION.DOWN:
                    if (_board[x + 1, y] == '#')
                        return DIRECTION.STOP;
                    else
                        return DIRECTION.DOWN;
                case DIRECTION.RIGHT:
                    if (_board[x, y + 1] == '#')
                        return DIRECTION.STOP;
                    else
                        return DIRECTION.RIGHT;
                case DIRECTION.LEFT:
                    if (_board[x, y - 1] == '#')
                        return DIRECTION.STOP;
                    else
                        return DIRECTION.LEFT;
                default:
                    return DIRECTION.STOP;
            }
        }

        public char GetContent(int x, int y)
        {
             return _board[x, y];
        }

        private void _GetLevelInfo()
        {
            string line;

            StreamReader data = new StreamReader(_name);
            line = data.ReadLine();
            string[] coords = line.Split();
            x = int.Parse(coords[0]);
            y = int.Parse(coords[1]);
            pX = int.Parse(coords[2]);
            pY = int.Parse(coords[3]);

            _board = new char[x, y];

            for (int i = 0; i < x; i++)
            {
                int counter = 0;
                line = data.ReadLine();
                foreach (char c in line)
                {
                    _board[i, counter] = c;
                    if (_board[i, counter] == '+')
                        _maxScore++;
                    counter++;
                }
            }
            data.Close();
        }
    }
}
