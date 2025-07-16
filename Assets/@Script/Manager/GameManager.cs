using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjAction
{
    private readonly Dictionary<MonoBehaviour, Action> _objectActionPairs = new Dictionary<MonoBehaviour, Action>();

    public void Add(MonoBehaviour keyObject, Action action)
    {
        if (_objectActionPairs.ContainsKey(keyObject))
            _objectActionPairs[keyObject] += action;
        else
            _objectActionPairs[keyObject] = action;
    }

    public void Call()
    {
        foreach (MonoBehaviour key in _objectActionPairs.Keys.ToArray())
        {
            if (key == null)
                _objectActionPairs.Remove(key);
            else
                _objectActionPairs[key]?.Invoke();
        }
    }
}

public class GameManager 
{
    public P1_Paper P1;
    public P2_Ink P2;

    public bool[] SwitchChannels = new bool[10];

    public ObjAction DeathAction = new ObjAction();

    public float Sec;
}
