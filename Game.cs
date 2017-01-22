using System;

namespace Pacman_DeepMind
{
    class Game
    {
        Level level;
        //Pacman pacman;

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
            //pacman = new pacman(level.pX, level.pY);

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
   
                level.Draw();

                isWorking = false;
            }
        }

        private void GameEnd()
        {
            //Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }
}
