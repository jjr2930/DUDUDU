using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
    public LayerMask mask;
    public NavMeshAgent agent = null;
    public GameObject point = null;
    Camera cam = null;
    private void Awake()
    {
        cam = Camera.main;
        point = GameObject.CreatePrimitive( PrimitiveType.Sphere );
        Destroy( point.GetComponent<Collider>() );
        point.GetComponent<Renderer>().material.color = Color.green;
        point.layer = LayerMask.NameToLayer( "Ignore Raycast" );
    }

    private void Update()
    {
        if ( Input.GetButtonDown( "Fire1" ) )
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = null;
            hit = Physics.RaycastAll( ray, 1000f, mask.value );
            agent.SetDestination( hit[0].point );
            point.transform.position = hit[0].point;
        }
    }

    private void OnGUI()
    {
        if(GUILayout.Button("jj"))
        {
            agent.isStopped = true;
            Debug.Log( "HI" ); 

        }
    }
}

    
