using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacebar : MonoBehaviour {
    public GameObject dotPrefab;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<MouseClick>().clicked)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(this.gameObject);
                Instantiate(dotPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
                //GetComponent<Rigidbody2D>().gravityScale = 0.4f;
                //GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-0.1f, 0.1f);
                //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
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
}
