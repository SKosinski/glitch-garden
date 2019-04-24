using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 100f;

    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.gameObject.GetComponent<Attacker>();

        if(attacker && health)
        {
            Destroy(gameObject);
            health.DealDamage(damage);
        }
    }

}
