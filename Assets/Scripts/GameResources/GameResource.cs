using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameResource : JLib.NetworkObject
{
    [SerializeField]
    string spriteName = "";

    [SerializeField]
    string hitSoundName ="";


    /// <summary>
    /// 플레이어가 이 자원을 채취한다.
    /// </summary>
    /// <param name="howMuch">한번에 얼마나 채취하는가.</param>
    public void Collected(int howMuch)
    {
        //예외처리.. 예외가 없도록 짜야한다... 혹시 모르니....
        if(howMuch <= 0)
        {
            Debug.LogErrorFormat( "GameResources.Collected=> name : {0}, howMuch can not be negative, howMuch: {1}",
                gameObject.name, howMuch );
            return;
        }
    }
}
