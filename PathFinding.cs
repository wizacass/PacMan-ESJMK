namespace Pacman_DeepMind
{
    using System;

    class PathFinding
    {
        private Level _level;

        /*
        private int _pX, _pY;
        private int _gX, _gY;

        public double distance;
        */

        public PathFinding(Level level)
        {
            _level = level;
        }

        /*public void SetData(int pX, int pY, int gX, int gY)
        {
            _pX = pX;
            _pY = pY;
            _gX = gX;
            _gY = gY;
        }*/

        public double CalculateDistance(int x, int y, int x1, int y1)
        {
            double distance = Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
            return distance;
        }

        public DIRECTION FindDir(int x, int y, int x1, int y1, DIRECTION current)
        {
            DIRECTION dir = current;

            double currentDistance = CalculateDistance(x, y, x1, y1);

            if(currentDistance > CalculateDistance(x, y, x1 - 1, y1) && _level.isWalkable[x1 - 1, y1])
            {
                dir = DIRECTION.UP;
            }
            if (currentDistance > CalculateDistance(x, y, x1 + 1, y1) && _level.isWalkable[x1 + 1, y1])
            {
                dir = DIRECTION.DOWN;
            }
            if (currentDistance > CalculateDistance(x, y, x1, y1 - 1) && _level.isWalkable[x1, y1 - 1])
            {
                dir = DIRECTION.LEFT;
            }
            if (currentDistance > CalculateDistance(x, y, x1, y1 + 1) && _level.isWalkable[x1, y1 + 1])
            {
                dir = DIRECTION.RIGHT;
            }

            return dir;
        }
    }
}
