using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSprite : MonoBehaviour
{
    // Start is called before the first frame update
    private int x = 0;
    private int counter = 0;
    private Vector2 startPosition;
    private float startAngle;
    private bool leftFinished = true;
    private bool rightFinished = true;

    void Start()
    {
        startAngle = Mathf.Deg2Rad * transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        ObrocWLewo();
        ObrocWPrawo();

    }
    void ObrocWLewo()
    {
        if (counter < 100)
        {
            if (leftFinished)
            {
                startAngle = Mathf.Deg2Rad * transform.eulerAngles.z;
                startPosition = transform.position;
                leftFinished = false;
            }
            Vector3 point = new Vector3(startPosition.x + (Mathf.Cos(startAngle) * -2.24f), startPosition.y + (Mathf.Sin(startAngle) * 2.24f), 0); // obliczyć na podstawie szerokości pająka i długości nogi
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(point, axis, Time.deltaTime * 10);
            Debug.Log(transform.eulerAngles.z);
            counter++;
        }
        else
        {
            leftFinished = true;
        }
    }
    void ObrocWPrawo()
    {
        if (counter >= 100 && counter < 200)
        {
            if (rightFinished)
            {
                startAngle = Mathf.Deg2Rad*transform.eulerAngles.z;
                startPosition = transform.position;
                rightFinished = false;
            }
            var x = Mathf.Cos(startAngle);
            var y = Mathf.Sin(startAngle);
            Vector3 point = new Vector3(startPosition.x + (Mathf.Cos(startAngle) * 2.24f), startPosition.y + (Mathf.Sin(startAngle) * 2.24f), 0); // obliczyć na podstawie szerokości pająka i długości nogi
            Vector3 axis = new Vector3(0, 0, -1);
            transform.RotateAround(point, axis, Time.deltaTime * 10);
            Debug.Log(transform.eulerAngles.z);
            counter++;
        }
        else
        {
            rightFinished = true;
        }
        if (counter >= 200)
        {
            counter = 0;
        }
    }
}
