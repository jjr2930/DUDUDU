using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NetworkObjectCommand
{
    public Enum command;
    public object data = null;
}


public class NetworkCommandBase
{
    public long networkID;
    public Enum eventName;
    public object value;
}

/// <summary>
/// 모든 제어는 서버에서하니 서버의 제어를 받자....
/// 네트워크에서 부여한 ID가 꼭 필요하다.
/// </summary>
namespace JLib
{
    public abstract class NetworkObject : JLib.JMonoBehaviour
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
    }
}