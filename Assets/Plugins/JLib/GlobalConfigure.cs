using System;
using JLib.Pathfind2D;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace JLib
{
    [Serializable]
    public class GlobalConfigure : MonoSingle<GlobalConfigure>
    {
        public float DEFAULT_RADIUS;
        public float DEFAULT_GLOSS;
        public float DEFAULT_ELASTICITY;
        public float DEFAULT_WEIGHT;

        #region pathfind configure
        public Dictionary<int, int> PATHFIND_WEIGHTS = new Dictionary<int, int>()
        {
            {4,3 },
            {8,1},
            {9,2 }
        };

        public int[] OBSTACLE_LAYER = new int[1]
        {
            10
        };
        
        public float PATHFIND_GRID_SIZE = 0.1f;
        public int PATHFIND_GRID_WIDTH = 10;
        public int PATHFIND_GRID_HEIGHT = 10;
        #endregion  
    }


}
