using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TestScript : MonoBehaviour {
    
    public float maxDelta = .01f;
    public Transform target = null;
    Stopwatch sw = null;
    private void Start()
    {
 
    }

    private void Update()
    {
        /*
        //0.00000405
        //0.00000262
        Vector3 currentPosition = transform.position;
        Vector3 velocity = target.position - currentPosition;
        velocity.Normalize();
        velocity = velocity * Time.deltaTime;
        Vector3 newPositon = Vector3.zero;

        float startTime = Time.realtimeSinceStartup;

        newPositon.x = Mathf.MoveTowards( currentPosition.x, target.position.x, Mathf.Abs( velocity.x ) );
        newPositon.y = Mathf.MoveTowards( currentPosition.y, target.position.y, Mathf.Abs( velocity.y ) );
        newPositon.z = Mathf.MoveTowards( currentPosition.z, target.position.z, Mathf.Abs( velocity.z ) );
        transform.position = newPositon;

        UnityEngine.Debug.Log( string.Format( "{0:f8}", ( Time.realtimeSinceStartup - startTime ) ) );

        if (transform.position == target.position)
        {   
            gameObject.SetActive( false );    
        }
        */

        /*
        //0.00000477
        //0.00000548
        //0.00000429
        float startTime = Time.realtimeSinceStartup;

        Vector3 curPosition = transform.position;
        Vector3 velocity = target.position - curPosition;
        velocity.Normalize();
        velocity *= Time.deltaTime;

        transform.position = curPosition + velocity;

        UnityEngine.Debug.Log( string.Format("{0:f8}",(Time.realtimeSinceStartup - startTime)));
        */
    }
}
