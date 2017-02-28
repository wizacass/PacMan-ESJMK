using System;
using System.Threading;

namespace Pacman_DeepMind
{
    public enum DIRECTION
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        STOP
    }

    class Game
    {
        Level level;
        Pacman pacman;
        Ghost ghost;
        SimpleAI ai;
        PathFinding path;

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
            level   = new Level("level1");
            pacman  = new Pacman(level.pX, level.pY);
            ghost   = new Ghost(level.gX, level.gY);
            ai      = new SimpleAI(level);
            path    = new PathFinding(level);

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

            //TODO fix conflict between inputs
                pacman.Input();
                //ghost.Input();

                pacman.SetDir(level.Check(pacman.getX(), pacman.getY(), pacman.GetDir()));
                pacman.Movement();

                ghost.SetDir(path.FindDir(pacman.getX(), pacman.getY(), ghost.getX(), ghost.getY(), pacman.GetDir()));
                ghost.SetDir(level.Check(ghost.getX(), ghost.getY(), ghost.GetDir()));
                ghost.Movement();
                
                SetData(pacman.getX(), pacman.getY(), ghost.getX(), ghost.getY());

                pacman.Update();
                ghost.Update();

                /*
                isWorking = ai.MoveNext();
                Tuple<int, int> coords = ai.Current;
                SetData(coords.Item1, coords.Item2);
                */

                level.Draw();
                Thread.Sleep(500);

                if(_score == _maxScore)
                {
                    isWorking = false;
                }

                if(pacman.getX() == ghost.getX() && pacman.getY() == ghost.getY())
                {
                    isWorking = false;
                }
            }
        }

        private void SetData(int pX, int pY, int gX, int gY)
        {
            _score = level.CheckScore(pX, pY, _score);

            level.SetPac(pX, pY);
            level.SetGhost(gX, gY, ghost.GetDir());
        }

        private void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }
}
