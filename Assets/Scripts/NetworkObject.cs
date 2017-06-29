using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkObjectCommand
{
    public EventNames command = EventNames.None;
    public object data = null;
}


public class NetworkCommandBase
{
    public long networkID;
}

/// <summary>
/// 모든 제어는 서버에서하니 서버의 제어를 받자....
/// 네트워크에서 부여한 ID가 꼭 필요하다.
/// </summary>
public class NetworkObject : JLib.JMonoBehaviour
{
    [SerializeField]
    long networkID = 0L;

    #region property

    long NetworkID
    {
        get
        {
            return networkID;
        }

        set
        {
            networkID = value;
        }
    }

    #endregion

    private void Awake()
    {
        JLib.GlobalEventQueue.RegisterListener( EventNames.Network_GameObjectShow, ListenGameObjectShow );
        JLib.GlobalEventQueue.RegisterListener( EventNames.Network_GameObjectHide, ListenGameObjectHide );
        OnAwake();
    }

    private void OnDestroy()
    {
        JLib.GlobalEventQueue.RemoveListener( EventNames.Network_GameObjectShow, ListenGameObjectShow );
        JLib.GlobalEventQueue.RemoveListener( EventNames.Network_GameObjectHide, ListenGameObjectHide );
        OnOnDestroy();
    }

    public void ListenGameObjectShow( object param )
    {
        gameObject.SetActive( true );
    }

    public void ListenGameObjectHide( object param )
    {
        gameObject.SetActive( false );
    }

    protected virtual void OnAwake() { }
    protected virtual void OnOnDestroy() { }

   
}
