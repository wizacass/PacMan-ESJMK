using System;
using System.Threading;

namespace Pacman_DeepMind
{
    public enum DIRECTION
    {
        STOP,
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    class Game
    {
        Level level;
        Pacman pacman;

        private int _score = 0;
        private int _maxScore;

        public Game()
        {
            Console.Title = "Pacman AI Project";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;

            GameStart();
            GameLoop();
            GameEnd();
        }

        private void GameStart()
        {
            level = new Level("level1");
            pacman = new Pacman(level.pX, level.pY);

            _maxScore = level.GetScore();

        }

        private void GameLoop()
        {
            SimpleAI ai = new SimpleAI(level);
            var isWorking = true;
            while(isWorking)
            {
                Console.Clear();
                Console.WriteLine("\tPacman Deep Mind");
                Console.WriteLine("   Score: " + _score + "\tMax: " + _maxScore);

                //pacman.Input();
                isWorking = ai.MoveNext();

                //pacman.SetDir(level.Check(pacman.getX(), pacman.getY(), pacman.GetDir()));
                //pacman.Movement();

                Tuple<int, int> coords = ai.Current;

                SetData(coords.Item1, coords.Item2);
                //SetData(pacman.getX(), pacman.getY());

                //pacman.Update();
                level.Draw();


                Thread.Sleep(1000);

                if(_score == _maxScore)
                {
                    isWorking = false;
                }
            }
        }

        private void SetData(int x, int y)
        {
            _score = level.CheckScore(x, y, _score);
            level.ClearTile(x, y);
            level.SetPac(x, y);
        }

        private void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }
}
