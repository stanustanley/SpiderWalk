using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLegTop : Leg
{
    public float EndPosition { get; set; }
    public float Range { get; set; }
    public float CurrentPosition { get; set; }
    private float newPosition;

    public override void PerformMove(float step)
    {
        newPosition = CurrentPosition - step;
        this.Range = 100000;
        if (newPosition <= Range && newPosition >= -Range)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, newPosition);
            CurrentPosition = newPosition;
        }
    }
}