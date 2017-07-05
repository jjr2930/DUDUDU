using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

[System.Serializable]
public class GameResource : JLib.NetworkObject, IInteractionObject
{
    [SerializeField]
    string spriteName = "";

    [SerializeField]
    string hitSoundName ="";


    bool IInteractionObject.Interact()
    {
        throw new NotImplementedException();
    }

    void IInteractionObject.InteractAsync( UnityAction<object> successCallback, UnityAction<object> failCallback )
    {
        throw new NotImplementedException();
    }


}
