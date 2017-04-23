using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {
    public Sprite block_green, block_yellow, block_red;
    public bool clicked;

    // Use this for initialization
    void Start()
    {
        clicked = false;
    }
	
    void Update()
    {

    }

	void OnMouseDown()
    {
        if (!clicked)
        {
            GetComponent<SpriteRenderer>().sprite = block_green;
            clicked = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = block_yellow;
            clicked = false;
        }
    }

    void OnMouseEnter()
    {
        if (!clicked)
        {
            GetComponent<SpriteRenderer>().sprite = block_red;
        }
    }

    void OnMouseExit()
    {
        if (!clicked)
        {
            GetComponent<SpriteRenderer>().sprite = block_yellow;
        }
    }

}
