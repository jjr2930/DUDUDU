using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace JLib.Pathfind2D
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(JLib.Pathfind2D.Grid))]
    public class PathFinder2D : MonoBehaviour
    {
        
        Grid grid = null;
      
        private void Start()
        {
            grid = GetComponent<Grid>();
            //SetWalkable();
        }


        //public void RefreshAllNode()
        //{
        //    RefreshNodeUsingSIze( 0, 0, width, height );
        //}

       

        //public void ListenAddObject( object param )
        //{
        //    GameObject p = param as GameObject;
        //    Vector3 min = p.GetComponent<Renderer>().bounds.min;
        //    Vector3 max = p.GetComponent<Renderer>().bounds.max;

        //    float startX = min.x;
        //    float startY = min.y;
        //    float endX = max.x;
        //    float endY = max.y;

        //    int minIndexX = (int)(startX / gridSize.x);
        //    int minIndexY = (int)(startY / gridSize.y);

        //    int maxIndexX = (int)(endX / gridSize.x);
        //    int maxIndexY = (int)(endY / gridSize.y);

        //    RefreshNodeUsingSIze( minIndexX, minIndexY, maxIndexX, maxIndexY );            
        //}

        //bool IsWalkable( RaycastHit2D[] colliders )
        //{
        //    for ( int i = 0 ; i < colliders.Length ; i++ )
        //    {
        //        int layer = colliders[i].transform.gameObject.layer;
        //        if ( GlobalConfigure.Instance.OBSTACLE_LAYER.Contains( layer ) )
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //int GetBiggestWeight( RaycastHit2D[] colliders )
        //{
        //    int biggestWeight = GlobalConfigure.Instance.PATHFIND_WEIGHTS[colliders[0].transform.gameObject.layer];

        //    for ( int i = 1 ; i < colliders.Length ; i++ )
        //    {
        //        int layer = colliders[i].transform.gameObject.layer;
        //        int weight = GlobalConfigure.Instance.PATHFIND_WEIGHTS[layer];
        //        if ( biggestWeight < weight )
        //        {
        //            biggestWeight = weight;
        //        }
        //    }

        //    return biggestWeight;
        //}

        //private void RefreshNodeUsingSIze( int _startX, int _startY, int _endX, int _endY )
        //{
        //    for ( int y = _startY ; y < _endY ; y++ )
        //    {
        //        for ( int x = _startX ; x < _endX ; x++ )
        //        {
        //            float findX = startX + x * gridSize.x;
        //            float findY= startY + y * gridSize.y;
        //            //ray to z axis
        //            var hits = Physics2D.BoxCastAll( new Vector2( findX, findY ), gridSize, 0, Vector2.zero );
        //            if ( hits == null || hits.Length == 0 )
        //            {
        //                grid.Nodes[y, x].Walkable = false;
        //                continue;
        //            }

        //            if ( !IsWalkable( hits ) )
        //            {
        //                grid.Nodes[y, x].Walkable = false;
        //                continue;
        //            }
        //            else
        //            {
        //                int weight = GetBiggestWeight(hits);
        //                grid.Nodes[y, x].Weight = weight;
        //            }
        //        }
        //    }
        //}
    }
}