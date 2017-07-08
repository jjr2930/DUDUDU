using UnityEngine;
using UnityEditor;
using System.Collections;


namespace JLib.Pathfind2D
{
    [CustomEditor( typeof( Grid) )]
    public class GridEditor : Editor
    {
        Grid script = null;
        private void Awake()
        {
            script = ( Grid )target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if ( GUI.changed )
            {
                script.CreateGrid( script.width, script.height );
            }
        }
    }
}