using UnityEngine;
using System.Collections;

namespace JLib.Pathfind2D
{
    [AddComponentMenu( "Pathfind2D/Agent" )]
    public class Agent : JMonoBehaviour
    {
        public float rotateSpeed = 60f;
        public float moveSpeed = 60f;

        protected Vector2 currentPosition;
        protected Vector2 nextPosition;
        protected Vector2 velocity;
        protected Quaternion currentRotation;
        protected Quaternion nextRotation;
        protected long instanceID;
        IEnumerator coroutine = null;

        private void Awake()
        {
            instanceID = gameObject.GetInstanceID();
            GlobalEventQueue.RegisterListener( DefaultEvent.PeekPathfindPosition, ListenPathfindEvent );
        }

        public void ListenPathfindEvent( object param )
        {
            PeekPointParameter p = param as PeekPointParameter;
            if ( p.instanceID == instanceID
                || p.instanceID == GlobalEventQueue.GlobalID )
            {
                ReqPathfind req = ParameterPool.GetParameter<ReqPathfind>();
                req.instanceID = this.GetInstanceID();
                req.startPosition = this.transform.position;
                req.endPosition = p.peekPoint;
                req.callback = PathfindCompleteCallback;
                GlobalEventQueue.EnQueueEvent( DefaultEvent.ReqPathfind, req );
            }
        } 

        public void PathfindCompleteCallback(Vector2[] path, bool isSuccess)
        {
            if(isSuccess)
            {
                if(null != coroutine)
                {
                    StopCoroutine( coroutine );
                }
                coroutine = MoveFollowPath( path );
                StartCoroutine( coroutine );
            }
            else
            {
                OnFailed();
            }
        }

        public virtual IEnumerator MoveFollowPath(Vector2[] path)
        {
            for ( int i = path.Length - 1 ; i >= 0 ; i-- )
            {
                //currentPosition = transform.position;
                nextPosition = path[i];

                for ( ;(Vector2)transform.position != nextPosition;)
                {
                    yield return null;
                    currentPosition = transform.position;
                    velocity = nextPosition - (Vector2)transform.position;
                    velocity.Normalize();

                    Vector2 newPosition = Vector2.zero;
                    newPosition.x = Mathf.MoveTowards( currentPosition.x, nextPosition.x, Mathf.Abs( velocity.x * moveSpeed * Time.deltaTime ) );
                    newPosition.y = Mathf.MoveTowards( currentPosition.y, nextPosition.y, Mathf.Abs( velocity.y * moveSpeed * Time.deltaTime ) );
                    transform.position = newPosition;
                }
            }


        }

        protected virtual void OnFailed()
        {

        }
    }
}