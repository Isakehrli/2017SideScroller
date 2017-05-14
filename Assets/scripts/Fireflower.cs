using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireflower : weapon
{
    public GameObject fireballPrefab;
    public override void Attack()
    {
        var fireball = Instantiate(fireballPrefab);
        fireball.transform.position = transform.position;
        fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        base.Attack();
    }
}
	
