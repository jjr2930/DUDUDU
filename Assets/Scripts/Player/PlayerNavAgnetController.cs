using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// NavMeshAgent의 제어를 위한 클래스
/// </summary>
[RequireComponent( typeof( NavMeshAgent ) )]
public class PlayerNavAgnetController : MonoBehaviour
{
    public enum PathfindState
    {
        None,
        Comlete,
        Stoped,
        Doing,
    }

    PathfindState status
    {
        get
        {
            ///중간 취소
            if(agent.hasPath && agent.isStopped)
            {
                return PathfindState.Stoped;
            }

            //하는 중 
            else if(agent.pathPending)
            {
                return PathfindState.Doing;
            }

            //역시 하는 중
            else if(agent.hasPath
                && agent.remainingDistance > agent.stoppingDistance)
            {
                return PathfindState.Doing;
            }
            
            //완료 .001은 임의의 최소값 부동소수점은정확하지 않다.
            else if(agent.hasPath
                && agent.remainingDistance == 0f )
            {
                return PathfindState.Comlete;
            }

            return PathfindState.None;
        }
    }
    NavMeshAgent agent = null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    private void Update()
    {
        
        
    }

    public void ListenPathfind(object param)
    {
        JLib.SingleParameter<Vector3> pos 
            = param as JLib.SingleParameter<Vector3>;

        agent.SetDestination( pos.value );
    }


    
}
