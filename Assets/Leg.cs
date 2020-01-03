using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Leg : MonoBehaviour
{
    public float Range { get; set; }
    public float CurrentPosition { get; set; }
    public abstract void PerformMove(float step);
    public bool moveFinished { get; set; }
}