using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {

        var player = coll.gameObject.GetComponent<player>();
        if (player != null) { 
            var enemies = FindObjectOfType<Enemy>();
            foreach(var e in enemies) {
                if(Vector3.Distance(this.transform.position, e.transform.position) < 10 {
                    e.gameObject.SetActive(false);
                }
            }
        }
    }
}