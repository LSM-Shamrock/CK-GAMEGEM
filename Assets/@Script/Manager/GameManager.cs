using System;
using UnityEngine;

public class GameManager 
{
    public Vector3 p1SavePoint;
    public Vector3 p2SavePoint;

    public Action saveAction;
    public Action deathAction;

    public bool[] switchChannels = new bool[10];
}
