using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UserTextInput : MonoBehaviour
{
    public GameObject inputField;
    Text text;

    private void Start()
    {
        text = inputField.GetComponent<Text>();
    }
    public void Text_Ended()
    {
        name = text.text;
        Debug.Log(name);
    }
}
