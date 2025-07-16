using System;
using UnityEngine;

public class GameManager 
{
    public P1_Paper P1;
    public P2_Ink P2;

    public bool[] SwitchChannels = new bool[10];

    public Action DeathAction;

    public float Sec;
}
