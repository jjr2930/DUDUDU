using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JLib.Pathfind2D
{
    [ExecuteInEditMode]
    [System.Serializable]
    public class Grid : JLib.JMonoBehaviour
    {
        public LayerMask nonWalkable;

        public int width;
        public int height;

        public Vector2 size;

        [SerializeField]
        Node[,] nodes;

        public Node[,] Nodes
        {
            get
            {
                return nodes;
            }
        }

        private void Awake()
        {
            CreateGrid( width, height );
        }

        public void OnDrawGizmos()
        {
            if ( null == Nodes )
                return;

            float startX = transform.position.x - ( size.x * width ) / 2f;
            float startY = transform.position.y - ( size.y * height ) / 2f;

            for ( int y = 0 ; y < height ; y++ )
            {
                for ( int x = 0 ; x < width ; x++ )
                {
                    float realX = startX + x * size.x;
                    float realY = startY + y * size.y;

                    if ( nodes[y, x].Walkable )
                    {
                        Gizmos.color = new Color( 0, 0, 0, 0.5f );
                        Gizmos.DrawWireCube( new Vector3( realX, realY, 0f ), new Vector3( size.x, size.y, 0f ) );
                    }

                    else
                    {
                        Gizmos.color = new Color( 1, 0, 0, 0.5f );
                        Gizmos.DrawCube( new Vector3( realX, realY, 0f ), new Vector3( size.x, size.y, 0f ) );
                    }
                }
            }
        }
        public void CreateGrid( int width, int height )
        {
            //y coord, x coord

            float startX = transform.position.x - ( size.x * width ) / 2f;
            float startY = transform.position.y - ( size.y * height ) / 2f;

            nodes = new Node[height, width];
            for ( int x = 0 ; x < width ; x++ )
            {
                for ( int y = 0 ; y < height ; y++ )
                {
                    nodes[y, x] = new Node();
                    nodes[y, x].GridX = x;
                    nodes[y, x].GridY = y;

                    float realX = startX + size.x * x;
                    float realY = startY + size.y * y;
                    nodes[y, x].WorldPosition = new Vector2( realX, realY );
                    nodes[y, x].CheckWalkable( ref size, nonWalkable.value );                    
                }
            }
        }
        public void SetWalkable()
        {
            var enumerator = Nodes.GetEnumerator();
            for ( ; enumerator.MoveNext() ; )
            {
                Node cur = (Node)enumerator.Current;
                cur.CheckWalkable( ref size, nonWalkable.value );
            }
        }
    }
    
}