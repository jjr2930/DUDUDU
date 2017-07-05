using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public interface IInteractionObject 
{
    /// <summary>
    /// 상호작용하기
    /// </summary>
    /// <returns>true : 상호작용 성공, false : 상호작용 실패</returns>
    bool Interact( InteractParameterBase param );
    void InteractAsync( InteractParameterBase param, UnityAction<object> successCallback, UnityAction<object> failCallback );
}
