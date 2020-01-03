using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DotBehaviorScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float angle = 0f;
    LeftLegMiddle leftLegMiddle;
    LeftLegTop leftLegTop;
    LeftLegBottom leftLegBottom;
    Leg leg;
    public static int counter = 0;
    string textToParse =
                "analogWrite(nogi_S, 40); " +
                "delay(cykl); " +
                "analogWrite(nogi_P, 160);" +
                "delay(cykl);" +
                "analogWrite(nogi_L, 160);" +
                "delay(cykl);" +
                "analogWrite(nogi_S, 160);" +
                "delay(cykl);" +
                "analogWrite(nogi_P, 40);" +
                "delay(cykl);" +
                "analogWrite(nogi_L, 40);" +
                "delay(cykl); ";
    List<LegDriver> drivers;
    public static int delayVariable =1000;
    LegDriver currDriver;

    // Start is called before the first frame update
    void Start()
    {
        //leftLegMiddle = FindObjectOfType<LeftLegMiddle>();
        //leftLegTop = FindObjectOfType<LeftLegTop>();
        // leg = FindObjectOfType<LeftLegBottom>();
        Sprite sprite = Resources.Load<Sprite>("Spider/bodY");
        CommandParser p = new CommandParser();
        drivers = p.ParseTextToDriversList(textToParse);
        if (drivers.Any())
        {
            currDriver = drivers.First();
        }
        //List<LegDriver> moves = new List<LegDriver>();
        //List<string> commands = new List<string>();
        //commands = textToParse.Trim().Split(';').ToList();
        
        //foreach (string command in commands)
        //{
        //    moves.Add(new LegDriver(command));
        //}
        //if (moves.Any())
        //{
        //    currMove = moves.First();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        currDriver.PerformMove();
        if (currDriver.MoveFinished)
        {
            currDriver = drivers[drivers.IndexOf(currDriver) + 1];
        }
    }
    //public void MiddleLegColorChange()
    //{
    //    if (leftLegMiddle.leg.color != Color.green)
    //    {
    //        leftLegMiddle.leg.color = Color.green;
    //    }
    //    else
    //    {
    //        leftLegMiddle.leg.color = Color.red;
    //    }

    //}
}
