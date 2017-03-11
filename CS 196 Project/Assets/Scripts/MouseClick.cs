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
	
    void Update()
    {
        if (GetComponent<Rigidbody2D>().angularVelocity != 0)
        {
            GetComponent<Rigidbody2D>().angularVelocity += 2.3f;
        }

    }

	void OnMouseDown()
    {
        if (!clicked)
        {
            GetComponent<SpriteRenderer>().material.color = Color.green;
            GetComponent<Rigidbody2D>().gravityScale = 0.4f;
            GetComponent<Rigidbody2D>().angularVelocity = 1;
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
            clicked = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;
            clicked = false;
        }
    }

    void OnMouseEnter()
    {
        if (!clicked)
        {
            GetComponent<SpriteRenderer>().material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        if (!clicked)
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }

}
