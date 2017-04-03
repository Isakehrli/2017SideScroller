﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -5;

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
	}
	
	void FixedUpdate () {

        //Apply  Movement 
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if (Input.GetButtonDown("Jump")){
            v.y = jumpSpeed;
        }

        rigidbody.velocity = v;

        //Check for out
        if(transform.position.y < deadZone) {
            Debug.Log("Current Position" + transform.position.y + "is lower than" + deadZone);
            GetOut();

        }


        //rigidbody.AddForce(new Vector2(x * speed, 0));


	}

    public void GetOut(){
        _GM.Setlives(_GM.GetLives() - 1);
        transform.position = startingPosition;
        Debug.Log("You're Out");
        
    }
}
