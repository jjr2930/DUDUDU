using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace JLib.Pathfind2D
{
    [System.Serializable]
    public class WeightData
    {
        public LayerMask layer;
        public int weight;
    }

    [ExecuteInEditMode]
    [RequireComponent(typeof(JLib.Pathfind2D.Grid))]
    
    public class PathFinder2D : MonoBehaviour
    {
        public WeightData[] weightData;
        /// <summary>
        /// key : layer, int : weight
        /// </summary>
        Dictionary<int, int> dicWeight;
        Grid grid = null;
        public List<Node> openNode = new List<Node>();
        private void Start()
        {
            dicWeight.Clear();
            for ( int i = 0 ; i < weightData.Length ; i++ )
            {
                dicWeight.Add( weightData[i].layer.value, weightData[i].weight );
            }
            grid = GetComponent<Grid>();
        }

        public void PathFind(Vector2 startPosition, Vector2 endPosition, UnityAction<Vector3[], bool> callback)
        {
            float originStartX = transform.position.x - ( grid.size.x * grid.width ) / 2f;
            float originStartY = transform.position.y - ( grid.size.y * grid.height ) / 2f;

            int startPositionIndexX = (int)(startPosition.x - originStartX / grid.size.x);
            int startPositionIndexY = (int)(startPosition.y - originStartY / grid.size.y);

            int endPositionIndexX = (int)(endPosition.x - originStartX / grid.size.x);
            int endPositionIndexY = (int)(endPosition.y - originStartY / grid.size.y);

            Node startNode = grid.Nodes[startPositionIndexY , startPositionIndexX];
            Node endNode = grid.Nodes[endPositionIndexX, endPositionIndexY];
        }

        public Vector2[] Routine(Node startNode , Node endNode)
        {

            //caculate neighbou's cost
            for ( int y = -1 ; y <= 1 ; y++ )
            {
                for ( int x = -1 ; x <= 1 ; x++ )
                {
                    //check outof range
                    if(startNode.GridX + x < 0 || startNode.GridX + x >= grid.width
                        || startNode.GridY + y < 0 || startNode.GridY + y >= grid.height)
                    {
                        continue;
                    }

                    Node neighbour = grid.Nodes[ y , x ];
                    neighbour.GCost = GetDistance( startNode, neighbour );
                    neighbour.HCost = GetDistance( neighbour, endNode );
                }
            }
        }

        int GetDistance( Node nodeA, Node nodeB )
        {
            int width = Mathf.Abs(nodeB.GridX - nodeA.GridX);
            int height = Mathf.Abs(nodeB.GridY - nodeA.GridY);
            int biggerEdge = (width > height) ? width : height;
            //대각선의 길이
            int diagonal = (width > height) ? width : height;
            biggerEdge -= diagonal;

            return diagonal * 14 + biggerEdge * 10;
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