using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

    public bool clicked;

    // Use this for initialization
    void Start()
    {
        clicked = false;
	}
	
	void OnMouseDown()
    {
        Debug.Log("clicked");
    }

}
