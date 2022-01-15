using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent s_gameEvent;
    void Awake()
    {
        s_gameEvent = this;
    }

    void Update()
    {
        if (s_gameEvent == null)
            s_gameEvent = this;
    }
    public event Action<string> OnChangeShapeType;
    public event Action<string> OnChangeShapeColor;
    public event Action OnSave;
    public event Action OnLoad;
    public void ChangeShapeType(string shape)
    {
        if (OnChangeShapeType != null)
        {
            OnChangeShapeType(shape);
        }
    }
    public void ChangeShapeColor(string color)
    {
        if (OnChangeShapeColor != null)
        {
            OnChangeShapeColor(color);
        }
    }
    public void Save()
    {

        if (OnSave != null)
        {
            OnSave();
        }
    }
    public void Load()
    {

        if (OnLoad != null)
        {
            OnLoad();
        }
    }
}
