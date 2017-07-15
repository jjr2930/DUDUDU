using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// addcomponent to maincamera
/// </summary>
public class MousePeeker : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask = new LayerMask();

    [SerializeField]
    [Range(0f,100f)]
    float range = 0f;

    Vector2 peekPosition = Vector2.zero;
    Ray2D ray = new Ray2D();
    RaycastHit2D[] hit = null;

    public void Update()
    {
        if ( Input.GetButtonDown( "Fire1" ) )
        {
            peekPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            hit = Physics2D.RaycastAll( peekPosition,Vector2.zero,range,layerMask.value );
            //걸린게 있을 때만 전달한다.

            if ( hit.Length > 0 )
            {
                JLib.Pathfind2D.PeekPointParameter param = JLib.ParameterPool.GetParameter<JLib.Pathfind2D.PeekPointParameter>();
                param.instanceID = JLib.GlobalEventQueue.GlobalID;
                param.peekPoint = hit[0].point; 
                JLib.GlobalEventQueue.EnQueueEvent( JLib.DefaultEvent.PeekPathfindPosition, param );
            }
        }
        //switch ( Input.touchCount )
        //{
        //    case 0:
        //        return;

        //    case 1:
        //        //선택 로직
        //        ray = Camera.main.ScreenPointToRay( Input.touches[0].position );
        //        hit = Physics.RaycastAll( ray, range, layerMask.value );
        //        //걸린게 있을 때만 전달한다.
        //        if ( hit.Length > 0 )
        //        {
        //            JLib.GlobalEventQueue.EnQueueEvent( JLib.DefaultEvent.TouchDown, hit );
        //        }
        //        break;

        //    case 2:
        //        //확대 로직
        //        break;

        //    default:
        //        Debug.Log( "MousePeeker.Update()=>is not supported" );
        //        break;

        //}
    }
}
