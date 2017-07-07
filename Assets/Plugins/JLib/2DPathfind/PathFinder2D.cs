using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib.Pathfind2D
{
    public static class PathFinder2D
    {
        static Grid grid = null;
        //static float gridSize = 0f;
        static int width = 0;
        static int height = 0;

        static float startX = 0f;
        static float startY = 0f;

        static Ray2D ray = new Ray2D();
        static RaycastHit[] hits = null;
        static Vector2 point = new Vector2();
        static Vector2 gridSize = new Vector2();

        static PathFinder2D()
        {
            width = GlobalConfigure.Instance.PATHFIND_GRID_WIDTH;
            height = GlobalConfigure.Instance.PATHFIND_GRID_HEIGHT;
            gridSize.x = GlobalConfigure.Instance.PATHFIND_GRID_SIZE;
            gridSize.y = GlobalConfigure.Instance.PATHFIND_GRID_SIZE;

            grid = new Grid( width, height );
        }

        public static void ListenAddObject( object param )
        {
            GameObject p = param as GameObject;
            Vector3 min = p.GetComponent<Renderer>().bounds.min;
            Vector3 max = p.GetComponent<Renderer>().bounds.max;

            float startX = min.x;
            float startY = min.y;
            float endX = max.x;
            float endY = max.y;

            int minIndexX = (int)(startX / gridSize.x);
            int minIndexY = (int)(startY / gridSize.y);

            int maxIndexX = (int)(endX / gridSize.x);
            int maxIndexY = (int)(endY / gridSize.y);

            for ( int y = minIndexY ; y <= maxIndexY ; y++ )
            {
                for ( int x = minIndexX ; x <= maxIndexX ; x++ )
                {
                    //ray to z axis
                    var colliders = Physics2D.BoxCastAll( new Vector2( x, y ), gridSize, 0, Vector2.zero );

                }
            }
        }

        public int GetBiggestWeight( Collider2D[] colliders )
        {
            for ( int i = 0 ; i < colliders.Length ; i++ )
            {
                for(int i=0 ; i<)
                GlobalConfigure.Instance.weights.
                colliders[i].gameObject.layer
            }
        }
    }
}