using UnityEditor;
using UnityEngine;

namespace Tracks
{
    [CustomEditor(typeof(TrackSection))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        
            TrackSection myScript = (TrackSection)target;
            
            if(GUILayout.Button("Add Straight Track")) 
                myScript.BuildStraightLine();
            
            if(GUILayout.Button("Add 30 deg curve")) 
                myScript.Build30Curve();
            
            if(GUILayout.Button("Add 30 deg Y section")) 
                myScript.Build30Y();
        }
    }
}