using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeType : MonoBehaviour
{
    private Mesh _cubeMesh, _sphereMesh, _cylinderMesh;
    /// <summary>
    /// Initialize The Private Mesh Variables With Default (Cube, Sphere, Cylinder) Meshes
    /// And Add The Event Handler.
    /// </summary>
    void Start()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        _cubeMesh = cube.GetComponent<MeshFilter>().sharedMesh;
        _sphereMesh = sphere.GetComponent<MeshFilter>().sharedMesh;
        _cylinderMesh = cylinder.GetComponent<MeshFilter>().sharedMesh;
        Destroy(cube);
        Destroy(sphere);
        Destroy(cylinder);


        // _cubeMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
        // _sphereMesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
        // _cylinderMesh = Resources.GetBuiltinResource<Mesh>("Cylinder.fbx");
        GameEvent.s_gameEvent.OnChangeShapeType += ChangeType;
    }

    /// <summary>
    /// Change The Shape's Type according to the passed String
    /// </summary>
    /// <param name="type">(Cube, Sphere, Cylinder)</param>
    public void ChangeType(string type)
    {
        if (type == "Cube")
        {
            this.GetComponent<MeshFilter>().sharedMesh = _cubeMesh;
        }
        else if (type == "Sphere")
        {
            this.GetComponent<MeshFilter>().sharedMesh = _sphereMesh;
        }
        else if (type == "Cylinder")
        {
            this.GetComponent<MeshFilter>().sharedMesh = _cylinderMesh;
        }
    }
}
