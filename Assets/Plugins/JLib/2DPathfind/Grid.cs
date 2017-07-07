using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib.Pathfind2D
{
    [SerializeField]
    public class Grid
    {
        [SerializeField]
        Node[,] nodes;

        public Node[,] Nodes
        {
            get
            {
                return nodes;
            }
        }
            
        public Grid( int width, int height )
        {
            CreateGrid( width, height );
        }

        public void CreateGrid(int width, int height)
        {
            //y coord, x coord
            nodes = new Node[height, width];
            for ( int x = 0 ; x < width ; x++ )
            {
                for ( int y = 0 ; y < height ; y++ )
                {
                    nodes[y, x] = new Node();
                    nodes[y, x].GridX = x;
                    nodes[y, x].GridY = y;
                }
            }
        }
    }
}