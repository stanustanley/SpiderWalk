using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LegDriver
{
    private List<Leg> legs;
    private float range;
    public bool MoveFinished { get; set; }
    public LegDriver(List<Leg> legs, float range)
    {
        this.legs = legs;
        this.range = range;

    }
    private LegDriver() { }
    public void PerformMove()
    {
        if (legs.Any())
            legs.ForEach(x => x.PerformMove(range));
 
    }
}
