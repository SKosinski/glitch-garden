using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float startingHealth = 200f;
    [SerializeField] GameObject explosionVFX;

    public void DealDamage(float damage)
    {
        startingHealth -= damage;
        if(startingHealth <= 0)
        {
            ExplosionVFX();
            Destroy(gameObject);
        }
    }

    private void ExplosionVFX()
    {
        if(!explosionVFX) { return; }
        GameObject explosionVFXobject = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(explosionVFXobject, 2f);
    }
}
