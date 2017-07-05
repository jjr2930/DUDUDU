using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

[System.Serializable]
public class GameResource : JLib.NetworkObject, IInteractionObject
{
    [SerializeField]
    protected string spriteName = "";

    [SerializeField]
    protected string hitSoundName = "";

    [SerializeField]
    protected string actionName = "";
    
    public bool Interact( InteractParameterBase param )
    {
        //not supported
        return false;
    }

    public void InteractAsync( InteractParameterBase param, UnityAction<object> successCallback, UnityAction<object> failCallback )
    {
        //get object from param.id;
        //do action
        Animator animator = null;
        animator.SetTrigger( actionName );
        
        JLib.NetworkManager.ReqUntilResponse(ref param, successCallback, failCallback );
    }
}
