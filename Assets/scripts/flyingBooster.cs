using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingBooster : MonoBehaviour {

    float timeStarted = 0;
    player player;

    public float lastForSeconds = 10;

    void OnCollisionEnter2D(Collision2D coll)
    {

        player = coll.gameObject.GetComponent<player>();
        if (player != null){
            player.canFly = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            timeStarted = Time.time;

            player.PowerUp();
        }
    }

    private void Update() {
        if (timeStarted != 0 && timeStarted + lastForSeconds < Time.time) {
            timeStarted = 0;
            player.canFly = false;
        }

    }
}
