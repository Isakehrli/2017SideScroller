using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telaport : MonoBehaviour
{

    public float movingspeed = 10;
    public bool canmove = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow)) { }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("any object collected");
        Vector2 v = GetComponent<Rigidbody>().velocity;
        if (Input.GetButtonDown("tube") && (v.y == 0 || canmove))
        { 
            v.y = movingspeed;
        }
    }
    public GameObject YouGameObject;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == YouGameObject)
        {
            transform.position = new Vector3(124, 6, 0);//(where you want to teleport)
        }
    }
}