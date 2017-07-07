using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    private void OnGUI()
    {
        if(GUILayout.Button("new"))
        {
            for ( int i = 0 ; i < 1000 ; i++ )
            {
                JLib.Pathfind2D.Grid grid = new JLib.Pathfind2D.Grid(10,10);
            }
        }
    }
}
