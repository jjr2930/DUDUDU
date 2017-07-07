using UnityEngine;
using System.Collections;

public class NetworkRectTransform : JLib.NetworkObject
{
    [SerializeField]
    float speed = 0;

    [SerializeField]
    bool isDirty = false;

    [SerializeField]
    Vector2 targetPosition = Vector2.zero;

    /// <summary>
    /// 현재까지 흐른시간
    /// </summary>
    float duringTime = 0;

    /// <summary>
    /// 총 걸리는 시간.
    /// </summary>
    float durationTime = 0f;

    /// <summary>
    /// 목표지점
    /// </summary>
    Vector3 destinationPosition = Vector3.zero;

    public void ListenPosition(object param)
    {
        Vector3 p = ( Vector3 )param;
        isDirty = false;

        float distance = ( rectTransform.position - p ).magnitude;
        durationTime = distance / speed;
        duringTime = 0;
    }

    private void Update()
    {
        if ( isDirty )
        {
        }
    }
}
