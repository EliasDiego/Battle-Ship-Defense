using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorMissile : Missile
{
    void FixedUpdate()
    {
        if(Health <= 0)
        {
            GameTracker.ReflectorMissileDestroyed++;
            Reset();
        }

        if(transform.position.y <= -6)
        {
            GameTracker.Health -= _Damage;
            Reset();
        }
        
        else
            transform.Translate(Vector2.down * _Speed * Time.deltaTime);
    }

    void Reset()
    {
        Health = 1;
        GetComponent<Collider2D>().enabled = true;
        gameObject.SetActive(false);
    }
}
