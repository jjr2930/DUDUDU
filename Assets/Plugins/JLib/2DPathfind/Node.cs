using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib.Pathfind2D
{
    [ExecuteInEditMode]
    [System.Serializable]
    public class Node : IHeapItem<Node>
    {
        /// <summary>
        /// position of real position
        /// </summary>
        public Vector2 WorldPosition { get; set; }

        /// <summary>
        /// from start
        /// </summary>
        public int GCost { get; set; }

        /// <summary>
        /// from end
        /// </summary>
        public int HCost { get; set; }

        public bool Walkable { get; set; }

        public int Weight { get; set; }

        public int GridX { get; set; }

        public int GridY { get; set; }

        public Node Parent { get; set; }

        public int HeapIndex { get; set; }
        public float FCost
        {
            get
            {
                return GCost + HCost + (Weight - 1 );
            }
        }

        public int CompareTo(Node other)
        {
            int compare = FCost.CompareTo(other.FCost);
            if(compare == 0)
            {
                compare = HCost.CompareTo( other.HCost );
            }

            return -compare;
        }

        public void CheckWalkable(ref Vector2 size , int nonWalkerbleLayers)
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll( WorldPosition, size, 0 );
            if ( hits == null
               || hits.Length == 0)
            {   
                Walkable = false;
                return;
            }

            Walkable = IsWalkable( hits, nonWalkerbleLayers );
        }

        bool IsWalkable(Collider2D[] colliders , int nonWalkable)
        {
            /*
             * bit caculate , is this colliders layer nonWalkable ?
             * a. collider layer bit = 0001;
             * b. nonWalkble Layer bit = 1001;
             * a | b = 0001
             * a | b == a
             * 
             * a. collider layerBit = 0100
             * b. nonWalkable layerbit = 1001
             * a | b = 0000;
            */
            for ( int i = 0 ; i < colliders.Length ; i++ )
            {
                Collider2D collider = colliders[i];
                int layerValue = LayerMask.GetMask(LayerMask.LayerToName( collider.gameObject.layer));
                if ( ( layerValue & nonWalkable ) == layerValue)
                {
                    return false;
                }
            }
            return true;
        }
    }
}