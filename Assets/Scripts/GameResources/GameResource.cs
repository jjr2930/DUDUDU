using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameResource : JLib.JMonoBehaviour
{
    [SerializeField]
    int amount = 0;

    [SerializeField]
    string spriteName = "";

    [SerializeField]
    string hitSoundName ="";
}
