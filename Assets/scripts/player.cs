﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -5;
    public bool canFly = false;

    public weapon currentWeapon;
    private List<weapon> weapons = new List<weapon>();

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    private Animator anim;
    public bool air;
    private SpriteRenderer sr;

    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();

        anim = GetComponent<Animator>();
        air = true;
        sr = GetComponent<SpriteRenderer>();

    }

	void FixedUpdate () {

        //Apply  Movement 
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;
        Debug.Log(v.x);

        if (v.x >0.1 && v.x <-0.1) {
            anim.SetBool("running", false);
        } else {
            anim.SetBool("running", true);
        }
        if (v.x > 0)
        {
            sr.flipX = false;
        }
        else if (v.x < 0)
        {
            sr.flipX = true;
        }
        if (Input.GetButtonDown("Jump") && (v.y ==0 || canFly) ){
            v.y = jumpSpeed;
        }

        if (v.y !=0) {
            anim.SetBool("air", true);
        } else {
            anim.SetBool("air", false);
        }

        rigidbody.velocity = v;
        // Attack with that weapon if you have
        if (Input.GetButtonDown("Fire1")&& currentWeapon != null) {
           currentWeapon.Attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            int i = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count;
            SetCurrentWeapon(weapons[i]);
        }
        //Check for out
        if (transform.position.y < deadZone) {
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
    public void PowerUp(){
        anim.SetTrigger("powered");
    }

    public void AddWeapon(weapon w)
    {
        weapons.Add(w);
        SetCurrentWeapon(w);
    }

    public void SetCurrentWeapon(weapon w)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = w;

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)  {
        air = false;
        var weapon = coll.gameObject.GetComponent<weapon>();
        if (weapon != null) {
            weapon.GetPickedup(this);
        }
    }
    void OnCollisionExit2D(Collision2D coll){
        air = true;
    }
}
