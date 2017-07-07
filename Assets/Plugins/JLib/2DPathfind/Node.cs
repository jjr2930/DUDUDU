using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib.Pathfind2D
{
    public class Node
    {
        int gridX = 0;
        int gridY = 0;

        /// <summary>
        /// How much far from the startPosition
        /// </summary>
        int gCost = 0;

        /// <summary>
        /// how much far from the endposition
        /// </summary>
        int hCost = 0;

        /// <summary>
        /// cost's weight when calculate real cost : (gcost + hcost) * weight
        /// </summary>
        int weight = 1;

        /// <summary>
        /// can move to here?
        /// </summary>
        bool walkable = true;

        public int GridX
        {
            get
            {
                return gridX;
            }
            set
            {
                gridX = value;
            }
        }

        public int GridY
        {
            get
            {
                return gridY;
            }

            set
            {
                gridY = value;
            }
        }

        public float FCost
        {
            get
            {
                return ( gCost + hCost ) * weight;
            }
        }

    }
}