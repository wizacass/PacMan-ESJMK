namespace Pacman_DeepMind
{
    using Genetic;
    using System.Collections.Generic;

    class Node
    {
        int x, y;   //Coords
        float G;    //distance from previous
        float H;    //distance from start
        float F;    //sum of G + H

        NodeState State;
        Node ParentNode; //previous Node
        List<Directions> Adjacent;
    }

    enum NodeState { Untested, Open, Closed }
}