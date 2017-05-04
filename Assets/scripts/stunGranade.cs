using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunGranade : throwable
{
    public float blastRadius = 20;

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
                StartCoroutine( Stun(e) );
                }
            }
        collider2D.enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
     }

    IEnumerator Stun(Enemy e)
    {
		var renderer = e.GetComponent<SpriteRenderer>();
        var animator = e.GetComponent<Animator>();

        e.enabled = false;
        if(animator != null){
            animator.enabled = false;
        }
        for (int i = 0; i < 8; i++)  {
            renderer.color = new Color(1, 1, 1, 1 - (i * .1f));
            yield return new WaitForSeconds(.1f);
        }

		yield return new WaitForSeconds(5);
        for (int i = 0; i < 11; i++)
        {
            renderer.color = new Color(1, 1, 1, i / 10);
            yield return new WaitForSeconds(.1f);
        }
        if (animator != null)
        {
            animator.enabled = true;
        }
        e.enabled = true;
    }
}