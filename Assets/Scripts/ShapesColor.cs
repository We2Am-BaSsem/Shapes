using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesColor : MonoBehaviour
{
    /// <summary>
    /// Add The Event Handler.
    /// </summary>
    void Start()
    {
        GameEvent.s_gameEvent.OnChangeShapeColor += ChangeColor;
    }

    /// <summary>
    /// Change The Shape's Color according to the passed Hex Value
    /// </summary>
    /// <param name="color">#FF0000 For Red, #00FF00 for Green, #0000FF for Blue</param>
    public void ChangeColor(string color)
    {
        Color tempcolor;
        if (ColorUtility.TryParseHtmlString(color, out tempcolor))
        {
            this.gameObject.GetComponent<Renderer>().material.color = tempcolor;
        }
    }
}
