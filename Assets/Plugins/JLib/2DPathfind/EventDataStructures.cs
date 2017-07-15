using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace JLib.Pathfind2D
{
    public class ReqPathfind
    {
        public long instanceID;
        public Vector2 startPosition;
        public Vector3 endPosition;
        public UnityAction<Vector2[],bool> callback;
    }

    public class PeekPointParameter
    {
        public long instanceID;
        public Vector2 peekPoint;
    }
}
