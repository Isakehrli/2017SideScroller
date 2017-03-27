using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public int health = 100;

    new Rigidbody2D rigidbody;

	void Start () {
        rigidbody = GetComponent<Rigidbody2D>(); 
	}
	
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(x, 0);

	}
}
