using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_DeepMind
{
    class Game
    {
        public Game()
        {
            GameStart();
            GameLoop();
            GameEnd();
        }

        private void GameStart()
        {
            Console.WriteLine("Pacman Game");

            Level level = new Level("level1");
        }

        private void GameLoop()
        {
            var isWorking = true;
            while(isWorking)
            {


                isWorking = false;
            }
        }

        private void GameEnd()
        {
            Console.WriteLine("Game Over!");
        }
    }
}
