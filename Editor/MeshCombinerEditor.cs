using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor (typeof(MeshCombiner))]
public class MeshCombinerEditor : Editor
{

    //Add button in inspector Section and Call fuction from script
    public override void OnInspectorGUI()
    {
        MeshCombiner meshCombiner = (MeshCombiner) target;

        if(GUILayout.Button("Combine Meshes"))
        {
            meshCombiner.CombineMeshes();
        }

    }

}
