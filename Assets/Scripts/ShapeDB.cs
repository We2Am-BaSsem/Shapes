using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDB : MonoBehaviour
{
    void Start()
    {
        GameEvent.s_gameEvent.OnSave += SaveShape;
        GameEvent.s_gameEvent.OnLoad += LoadShape;
    }

    /// <summary>
    /// Save The Shape's Characteristics Into The Data Base When Event Is Fired 
    /// Store The Type (Cube, Sphere, Cylender), Color (red, Green, Blue), Rotation 
    /// </summary>
    void SaveShape()
    {
        DBManager.s_dbManager.Save(
        this.GetComponent<MeshFilter>().sharedMesh.ToString().Replace(" (UnityEngine.Mesh)", ""),
        ColorUtility.ToHtmlStringRGB(this.GetComponent<Renderer>().material.color),
        this.transform.localRotation.x,
        this.transform.localRotation.y,
        this.transform.localRotation.z
        );
    }
    /// <summary>
    /// Load The Shape's Characteristics From The Data Base When Event Is Fired 
    /// restore The Type (Cube, Sphere, Cylender), Color (red, Green, Blue), Rotation 
    /// </summary>
    void LoadShape()
    {
        var shape = DBManager.s_dbManager.Load();
        this.GetComponent<ShapeType>().ChangeType(shape.Item1);
        this.GetComponent<ShapesColor>().ChangeColor(shape.Item2);
        this.transform.rotation = new Quaternion(shape.Item3, shape.Item4, shape.Item5, this.transform.rotation.w);
    }
}
