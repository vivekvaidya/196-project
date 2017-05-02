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
        if (clicked)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().gravityScale = 0.4f;
                GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-0.1f, 0.1f);
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
            }
        }
        if (GetComponent<Rigidbody2D>().angularVelocity > 0)
        {
            GetComponent<Rigidbody2D>().angularVelocity += 2.3f;
        }
        else if (GetComponent<Rigidbody2D>().angularVelocity < 0)
        {
            GetComponent<Rigidbody2D>().angularVelocity -= 2.3f;
        }

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
