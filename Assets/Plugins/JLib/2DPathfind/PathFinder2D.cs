using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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

    //[ExecuteInEditMode]
    [AddComponentMenu("Pathfind2D/Pathfinder")]
    [RequireComponent(typeof(JLib.Pathfind2D.Grid))]
    
    public class PathFinder2D : MonoBehaviour
    {
        public WeightData[] weightData;
        
        /// <summary>
        /// key : layer, int : weight
        /// </summary>ㅣ
        Dictionary<int, int> dicWeight = new Dictionary<int, int>();
        Grid grid = null;

        List<Node> openNodes = new List<Node>();
        HashSet<Node> closeNodes = new HashSet<Node>();
        Node currentNode = null;

        Vector2[] path = null;

        private void Start()
        {
            GlobalEventQueue.RegisterListener( DefaultEvent.PathObstacleMove, ListenMoveObstacle );
            GlobalEventQueue.RegisterListener( DefaultEvent.ReqPathfind, ListenReqPathfind );
            dicWeight.Clear();
            for ( int i = 0 ; i < weightData.Length ; i++ )
            {
                dicWeight.Add( weightData[i].layer.value, weightData[i].weight );
            }
            grid = GetComponent<Grid>();
        }

        private void OnDestroy()
        {
            GlobalEventQueue.RemoveListener( DefaultEvent.PathObstacleMove, ListenMoveObstacle );
        }

        private void OnDrawGizmos()
        {
            if(null != path
                && path.Length != 0)
            {
                //draw fistPoint
                //creat point
                Gizmos.color = Color.green;
                Gizmos.DrawSphere( path[0], 0.1f );
                for ( int i = 1 ; i< path.Length ;i++ )
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere( path[i], 0.1f );
                    Gizmos.DrawLine( path[i - 1], path[i] );
                }
            }
        }

        /// <summary>
        /// fixme : it should be optimized
        /// </summary>
        /// <param name="param"></param>
        private void ListenMoveObstacle(object param)
        {
            grid.SetWalkable();
        }

        public void ListenReqPathfind(object param)
        {
            ReqPathfind p = param as ReqPathfind;
            PathFind( p.startPosition, p.endPosition, p.callback );
        }
        public void PathFind(Vector2 startPosition, Vector2 endPosition, UnityAction<Vector2[], bool> callback)
        {
            Vector2[] result = null;

            bool isSuccess = false;

            float originStartX = transform.position.x - ( grid.size.x * grid.width ) / 2f;
            float originStartY = transform.position.y - ( grid.size.y * grid.height ) / 2f;

            int startPositionIndexX = (int)Math.Round((startPosition.x - originStartX) / grid.size.x);
            int startPositionIndexY = (int)Math.Round((startPosition.y - originStartY) / grid.size.y);

            int endPositionIndexX = (int)Math.Round((endPosition.x - originStartX) / grid.size.x);
            int endPositionIndexY = (int)Math.Round((endPosition.y - originStartY) / grid.size.y);

            Node startNode = grid.Nodes[startPositionIndexY , startPositionIndexX];
            Node endNode = grid.Nodes[endPositionIndexY, endPositionIndexX];

            openNodes.Clear();
            closeNodes.Clear();

            startNode.GCost = 0;
            startNode.HCost = GetDistance( startNode, endNode );

            isSuccess = Routine( startNode, endNode, out result );

            if ( null != callback )
            {
                callback( result, isSuccess );
            }
        }

        public bool Routine( Node startNode, Node endNode, out Vector2[] result )
        {
            //pathStack.Push( startNode );
            openNodes.Add( startNode );
            //InputNeighboursToOpenNodes( startNode, endNode );
            float limitTime = Time.realtimeSinceStartup + 10;
            ///for is faster than while
            for ( ; openNodes.Count > 0 ; )
            {
                if(limitTime < Time.realtimeSinceStartup)
                {
                    //Debug.Log( "Found infinite loop" );
                    result = null;
                    return false;
                }

                currentNode = GetShortestNodeFromOpenNodes();
                openNodes.Remove( currentNode );
                closeNodes.Add( currentNode );

                //Debug.LogFormat( "current node index : x : {0} , y:{0}",
                    //currentNode.GridX, currentNode.GridY );
                if(currentNode == endNode)
                {
                    result = GetSimplePath( startNode , endNode );
                    return true;
                }

                InputNeighboursToOpenNodes( currentNode , endNode);
            }

            result = null;
            return false;
        }

        Node GetShortestNodeFromOpenNodes()
        {
            Node shortestNode = openNodes[0];
            for(int i= 1 ; i<openNodes.Count ; i++ )
            {
                if ( shortestNode.FCost > openNodes[i].FCost
                    || ( shortestNode.FCost == openNodes[i].FCost && shortestNode.HCost > openNodes[i].HCost ) )
                {
                    shortestNode = openNodes[i];
                }
            }

            return shortestNode;
        }

        Vector2[] GetSimplePath( Node startNode, Node endNode )
        {
            List<Vector2> pathList = new List<Vector2>();
            List<Vector2> simplePath = new List<Vector2>();
            Node currentNode = endNode;
            for ( ; currentNode != startNode; )
            {
                pathList.Add( currentNode.WorldPosition );
                currentNode = currentNode.Parent;
            }
            //add last
            pathList.Add( currentNode.WorldPosition );
            int beforeDeltaXSign = 0;
            int beforeDeltaYSign = 0;

            int nextDeltaXSign = 0;
            int nextDeltaYSign = 0;



            /*
             * 000
             * **000
             * ****0
             * 0 : pathpoint
             */
            //addFirst 
            simplePath.Add( pathList[0] );
            for ( int i = 1 ; i < pathList.Count - 1 ; i++ )
            {
                beforeDeltaXSign = Math.Sign( pathList[i].x - pathList[i - 1].x );
                beforeDeltaYSign = Math.Sign( pathList[i].y - pathList[i - 1].y );

                nextDeltaXSign = Math.Sign( pathList[i + 1].x - pathList[i].x );
                nextDeltaYSign = Math.Sign( pathList[i + 1].y - pathList[i].y );

                //if sign is same, it need not contain to pathlist;
                if ( beforeDeltaXSign != nextDeltaXSign
                    || beforeDeltaYSign != nextDeltaYSign )
                {
                    simplePath.Add( pathList[i] );
                }
            }
            //addLast
            simplePath.Add( pathList[pathList.Count - 1] ); 
            return simplePath.ToArray();
        }

        /// <summary>
        /// get validate neighbour node
        /// </summary>
        /// <param name="node">current node</param>
        /// <param name="endNode">destinatio node about this pathfind</param> 
        void InputNeighboursToOpenNodes( Node node, Node endNode )
        {
            for ( int y = node.GridY - 1 ; y <= node.GridY + 1 ; y++ )
            {
                for ( int x = node.GridX - 1 ; x <= node.GridX + 1 ; x++ )
                {
                    //check outof range
                    if ( y < 0
                        || x < 0
                        || y >= grid.height
                        || x >= grid.width )
                    {
                        continue;
                    }

                    bool isWalkable = grid.Nodes[y,x].Walkable;
                    bool isContainClose = closeNodes.Contains(grid.Nodes[y,x]);
                    //check is nonvalidate neighbour
                    if ( !isWalkable || isContainClose )
                    {
                        continue;
                    }

                    //check not need to go
                    Node neighbour = grid.Nodes[y,x];
                    int neighbourNewGCost = currentNode.GCost + GetDistance( currentNode, neighbour);
                    if(neighbour.GCost < neighbourNewGCost
                        && openNodes.Contains( neighbour ) )
                    {
                        continue;
                    }

                    
                    neighbour.GCost = neighbourNewGCost;
                    neighbour.HCost = GetDistance( neighbour, endNode );
                    neighbour.Parent = currentNode;
                    if ( !openNodes.Contains( neighbour ) )
                    {
                        openNodes.Add( neighbour );
                    }

                }
            }
        }

        private void CalculateNeighbourCost( Node currentNode, Node endNode )
        {
            for ( int y = currentNode.GridY - 1 ; y <= currentNode.GridY + 1 ; y++ )
            {
                for ( int x = currentNode.GridX - 1 ; x <= currentNode.GridX + 1 ; x++ )
                {
                    //check outof range
                    if( y < 0           
                        || x <0
                        || y >= grid.height
                        || x >= grid.width )
                    {
                        continue;
                    }

                    Node neighbour = grid.Nodes[ y , x ];

                    if ( neighbour.Walkable )
                    {
                        neighbour.GCost = GetDistance( currentNode, neighbour );
                        neighbour.HCost = GetDistance( neighbour, endNode );
                        openNodes.Add( neighbour );
                    }
                }
            }
        }
        
        int GetDistance( Node nodeA, Node nodeB )
        {
            int width = Mathf.Abs(nodeB.GridX - nodeA.GridX);
            int height = Mathf.Abs(nodeB.GridY - nodeA.GridY);
            int biggerEdge = (width > height) ? width : height;
            //대각선의 길이
            
            int diagonal = (width > height) ? height : width;
            biggerEdge -= diagonal;

            return diagonal * 14 + biggerEdge * 10;
        }   
    }
}