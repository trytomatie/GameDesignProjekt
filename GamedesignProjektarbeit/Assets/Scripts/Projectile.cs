using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public StatusManager origin;
    public Transform target;
    public int damage;
    public float projectileSpeed = 1;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Instanciate(StatusManager origin, int damage, Transform target, bool lockOn)
    {
        this.origin = origin;
        this.damage = damage;
        this.target = target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            MoveToTarget(target);
        }
        else
        {
            // Moves forward if no specified target
            rb.velocity = transform.right * projectileSpeed; 
        }
    }

    private void MoveToTarget(Transform target)
    {
        rb.velocity = GameManager.NormalizedDirection(transform.position, (Vector2)target.position) * projectileSpeed;
    }



    private void ApplyDamage(StatusManager other)
    {
        other.ApplyDamage(damage);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StatusManager otherStatus = collision.gameObject.GetComponent<StatusManager>();
        if (otherStatus != null && otherStatus.faction != origin.faction)
        {
            ApplyDamage(otherStatus);
        }
    }
}
