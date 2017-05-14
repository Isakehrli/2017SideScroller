using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : throwable
{
    public float blastRadius = 5;
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        var player = coll.gameObject.GetComponent<player>();
       
        if (isActive && player == null){
            Explode();
        }
    }
    public void Explode()
    { 
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var e in enemies) {
                if (Vector3.Distance(this.transform.position, e.transform.position) < blastRadius) {
                    e.gameObject.SetActive(false);
                }
            }
        gameObject.SetActive(false);
     }
}