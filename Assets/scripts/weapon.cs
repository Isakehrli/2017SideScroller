using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    // Use this for initialization
    protected new Rigidbody2D rigidbody2D;
    protected new Collider2D collider2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public virtual void Attack() {

    }
    public virtual void GetPickedup(player player) {
        Debug.Log("GetPickedup");
        collider2D.enabled = false;
        rigidbody2D.isKinematic = true;
        rigidbody2D.velocity = new Vector2();
        transform.parent = player.transform;
        transform.localScale = new Vector3(.05f, .05f);
        transform.localPosition = new Vector3(.05f, .05f);

    }
}
