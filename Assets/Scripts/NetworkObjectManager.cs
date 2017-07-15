
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

public static class NetworkObjectManager 
{
    static Dictionary<long, Dictionary<Enum, UnityAction<object>>> evnetListener
        = new Dictionary<long, Dictionary<Enum, UnityAction<object>>>();

    /// <summary>
    /// 리스너들 추가하기
    /// </summary>
    public static void AddListenerProcess()
    {

    }
    
    /// <summary>
    /// 네트워크 메시지를 듣는 리스너
    /// </summary>
    /// <param name="param"></param>
    public static void ListenNetworkMessage(object param)
    {
        NetworkCommandBase p = param as NetworkCommandBase;
        long id = p.networkID;
        NetworkObject foundedObject = null;
        
    }
}
