using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.AI;

public class ForceBakeNavMesh : MonoBehaviour
{
    [MenuItem("Tools/Force Bake NavMesh")]
    static void Bake()
    {
        NavMeshBuilder.BuildNavMesh(); // ǿ�ƺ決
    }
}