using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_DeepMind
{
    class Game
    {
        Level level;

        public Game()
        {
            GameStart();
            GameLoop();
            GameEnd();
        }

        private void GameStart()
        {
            Console.WriteLine("\tPacman Game");

            level = new Level("level1");
        }

        private void GameLoop()
        {
            var isWorking = true;
            while(isWorking)
            {
                level.Draw();

                isWorking = false;
            }
        }

        private void GameEnd()
        {
            Console.WriteLine("Game Over!");
        }
    }
}
