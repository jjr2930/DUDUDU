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
    
    #endregion

    PlayerMove,
    EnterTileCollider,

    /// <summary>
    /// 손가락 하나로 화면 터치
    /// </summary>
    Peek
}

