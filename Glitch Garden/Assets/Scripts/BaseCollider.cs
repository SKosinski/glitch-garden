﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        FindObjectOfType<HealthDisplay>().TakeALife();
        Destroy(collision.gameObject);
    }
}
