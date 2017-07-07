using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerNavAgnetController : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    public enum PathfindState
    {
        None,
        Comlete,
        Stoped,
        Doing,
    }
    
    private void Awake()
    {
        JLib.GlobalEventQueue.RegisterListener( JLib.DefaultEvent.TouchDown, ListenPathfind );
    }

    private void OnDestroy()
    {
        JLib.GlobalEventQueue.RemoveListener( JLib.DefaultEvent.TouchDown, ListenPathfind );
    }

    private void Update()
    {
    }

    public void ListenPathfind(object param)
    {
        RaycastHit2D[] hits = (RaycastHit2D[]) param;

        for(int i= 0 ; i<hits.Length ; i++ )
        {
            if(hits[i].transform.gameObject.layer == layerMask)
            {

                return;
            }
        }
    }
}
