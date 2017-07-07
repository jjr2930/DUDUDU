using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventNames
{
    None,
    #region networkEnum
    /// <summary>
    /// 해당 게임오브젝트를 숨긴다.
    /// </summary>
    Network_GameObjectHide,

    /// <summary>
    /// 해당 게임오브젝트를 보여준다.
    /// </summary>
    Network_GameObjectShow,
    
    /// <summary>
    /// 넷플레이어의 위치
    /// </summary>
    Network_NPlayerPosition,
    /// <summary>
    /// 넷플레이어의 회전값
    /// </summary>
    Network_NPlayerRotation,
    #endregion

    PlayerMove,
    EnterTileCollider,

    

}

