using UnityEngine;
using System.Collections;

/// <summary>
/// 게임에 쓰일 설정값들을 저장한다.
/// 
/// </summary>
public class Configure : JLib.MonoSingle<Configure>
{
    /// <summary>
    /// 플레이어의 움직임 속도
    /// </summary>
    public float PlayerMoveSpeed = 10;
}
