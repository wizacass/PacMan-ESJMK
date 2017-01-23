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
            var isWorking = true;
            while(isWorking)
            {
                Console.Clear();
                Console.WriteLine("\tPacman Deep Mind");
                Console.WriteLine("   Score: " + _score + "\tMax: " + _maxScore);

                pacman.Input();

                pacman.SetDir(level.Check(pacman.getX(), pacman.getY(), pacman.GetDir()));
                pacman.Movement();

                _score = level.CheckScore(pacman.getX(), pacman.getY(), _score);
                level.ClearTile(pacman.getX(), pacman.getY());
                level.SetPac(pacman.getX(), pacman.getY());

                pacman.Update();
                level.Draw();


                Thread.Sleep(100);

                if(_score == _maxScore)
                {
                    isWorking = false;
                }
            }
        }

        private void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }
}
