using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -5;
    public bool canFly = false;

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
        if(v.x >0.1 && v.x <-0.1) {
            anim.SetBool("running", false);
        } else {
            anim.SetBool("running", true);
        }
        if (v.x > 0)
            sr.flipX = false;
        else if (v.x < 0)
            sr.flipX = true;

        if (Input.GetButtonDown("Jump") && (v.y ==0 || canFly) ){
            v.y = jumpSpeed;
        }

        if(air) {
            anim.SetBool("air", true);
        } else {
            anim.SetBool("air", false);
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
    public void PowerUp(){
        anim.SetTrigger("powered");
    }

    void OnCollisionEnter2D(Collision2D col)  {
        air = false;
    }
    void OnCollisionExit2D(Collision2D col){
        air = true;
    }
}
