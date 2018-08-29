using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {

    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeftPressed;
    public static event ButtonPressed OnRightPressed;

    public bool left;
    /*
    private void Update()
    {
        if (Input.GetButton("left") && OnLeftPressed != null && left)
            OnLeftPressed();
        else if (Input.GetButton("right") && OnRightPressed != null)
            OnRightPressed();


    }
    
    private static bool GetKey(string v)
    {
        throw new NotImplementedException();
    }
    */
    private void OnMouseDown()
    {
        if (OnLeftPressed != null && left)
            OnLeftPressed();
        else if (OnRightPressed != null)
            OnRightPressed();
    }
}
