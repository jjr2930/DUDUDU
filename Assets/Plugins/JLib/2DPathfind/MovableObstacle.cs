using UnityEngine;
using System.Collections;

namespace JLib.Pathfind2D
{
    [AddComponentMenu("Pathfind2D/MovableObstacle")]
    public class MovableObstacle : JLib.JMonoBehaviour
    {
        float beforeX = 0;
        float beforeY = 0;
        float currentX = 0;
        float currentY = 0;
        Vector3 currentPos;
        private void Start()
        {
            currentPos = transform.position;
            beforeX = currentPos.x;
            beforeY = currentPos.y;
        }

        private void Update()
        {
            currentPos = transform.position;
            currentX = currentPos.x;
            currentY = currentPos.y;

            if( beforeX != currentX
                || beforeY != currentY)
            {
                GlobalEventQueue.EnQueueEvent( DefaultEvent.PathObstacleMove, this );
                beforeX = currentX;
                beforeY = currentY;
            }
        }
    }
}