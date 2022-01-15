using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShapesRotation : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public float RotationSpeed = 5.0f;
    public void OnBeginDrag(PointerEventData data)
    {
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.button != PointerEventData.InputButton.Right)
            return;
        float rotX = data.delta.x * RotationSpeed * Mathf.Deg2Rad;
        float rotY = data.delta.y * RotationSpeed * Mathf.Deg2Rad;

        this.transform.Rotate(Vector3.up, -rotX);
        this.transform.Rotate(Vector3.right, rotY);
    }
}
