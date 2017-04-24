using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float blastRadius = 5;
    public bool isActive = false;

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;

    void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isActive) {
            Throw();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        var player = coll.gameObject.GetComponent<player>();
        if (player != null && !isActive)   {
            GetPickedup(player);
        }
        if (isActive && player == null){
            Explode();
        }
    }
    public void Throw() {
        collider2D.enabled = true;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2();
        transform.parent = null;

    }
    public void GetPickedup(player player)  {

        Debug.Log("GetPickedup");
        isActive = true;
        collider2D.enabled = false;
        rigidbody2D.isKinematic = true;
        rigidbody2D.velocity = new Vector2();
        transform.parent = player.transform;
        transform.localScale = new Vector3(.2f, .2f);
        transform.localPosition = new Vector3(.2f, .2f);

    }
    public void Explode()
    { 
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var e in enemies) {
                if (Vector3.Distance(this.transform.position, e.transform.position) < blastRadius) {
                    e.gameObject.SetActive(false);
                }
            }
        this.gameObject.SetActive(false);
     }
}