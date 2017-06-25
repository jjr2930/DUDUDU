using UnityEngine;
using System.Collections;

public class PlayerTransformController : JLib.JMonoBehaviour
{
    private void Awake()
    {
        JLib.GlobalEventQueue.RegisterListener( EventNames.PlayerMove, ListenPlayerMove );
    }

    //트랜스폼을 제어할 이벤트를 듣고 행동한다.
    public void ListenPlayerMove( object param )
    {
        JLib.SingleParameter<Vector3> direction
            = JLib.ParameterPool.GetParameter<JLib.SingleParameter<Vector3>>();

        JLib.V3Extension.Multiply( ref direction.value, Configure.Instance.PlayerMoveSpeed );

        transform.Translate( direction.value );
    }
}
