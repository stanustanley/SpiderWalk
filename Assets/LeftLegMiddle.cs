using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLegMiddle : Leg
{
    // Start is called before the first frame update

    public SpriteRenderer leg;

    public override void PerformMove(float step)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        leg = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        
    }
    

  
}
