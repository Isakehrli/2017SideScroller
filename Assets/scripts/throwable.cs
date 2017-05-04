using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwable : weapon {
    public bool isActive = false;
    public override void Attack()
    {
        collider2D.enabled = true;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(5, 0);
        transform.parent = null;

    }
   public override void GetPickedup(player player)  {
        if (isActive) {
            return;
       }
        isActive = true;
        base.GetPickedup(player);
    }
}
