using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// By Christian Scherzer
/// </summary>
public class Projectile : MonoBehaviour
{

    public StatusManager origin;
    public Transform target;
    public int damage;
    public float projectileSpeed = 1;
    public bool lockOn = false;
    public Vector2 targetDirectionOnAttackDeclaration;
    public int stunValue = 0;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Despawn Projectile after 10 seconds
        Destroy(gameObject,10f);
    }

    /// <summary>
    /// Initializes Projectile
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="damage"></param>
    /// <param name="projectileSpeed"></param>
    /// <param name="target"></param>
    /// <param name="lockOn"></param>
    public void Initialize(StatusManager origin, int damage,float projectileSpeed, Transform target, bool lockOn)
    {
        this.origin = origin;
        this.damage = damage;
        this.target = target;
        this.projectileSpeed = projectileSpeed;
        this.lockOn = lockOn;
        targetDirectionOnAttackDeclaration = GameManager.NormalizedDirection(transform.position, target.position);


    }

    // Update is called once per frame
    void Update()
    {
        // Check for target
        if(target != null)
        {
            MoveToTarget(target);
        }
        else
        {
            // Moves forward if no specified target
            //rb.velocity = transform.right * projectileSpeed; 

            // Moves to last target Position
            rb.velocity = targetDirectionOnAttackDeclaration * projectileSpeed;
        }
        if (target != null && target.GetComponent<StatusManager>().Hp < 0 && lockOn == true)    
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Moves to target 
    /// </summary>
    /// <param name="target"></param>
    private void MoveToTarget(Transform target)
    {
        // Check if projectile is locked on target or not
        if(lockOn && target != null)
        {
            rb.velocity = GameManager.NormalizedDirection(transform.position, (Vector2)target.position) * projectileSpeed;
            targetDirectionOnAttackDeclaration = GameManager.NormalizedDirection(transform.position, (Vector2)target.position);
        }
        else
        {
            rb.velocity = targetDirectionOnAttackDeclaration * projectileSpeed;
        }

    }


    /// <summary>
    /// Apply Damage to target
    /// </summary>
    /// <param name="other"></param>
    private void ApplyDamage(StatusManager other)
    {
        other.ApplyDamage(damage);
    }

    /// <summary>
    /// Apply Stun to target
    /// </summary>
    /// <param name="other"></param>
    private void ApplyStun(StatusManager other)
    {
        other.stunValue += stunValue;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StatusManager otherStatus = collision.gameObject.GetComponent<StatusManager>();
        if (otherStatus != null && otherStatus.faction != origin.faction)
        {
            ApplyDamage(otherStatus);
            ApplyStun(otherStatus);
            Destroy(gameObject);
        }
    }



    public void OnTriggerEnter2D(Collider2D collider)
    {
        StatusManager otherStatus = collider.gameObject.GetComponent<StatusManager>();
        if (otherStatus != null && otherStatus.faction != origin.faction)
        {
            ApplyDamage(otherStatus);
            ApplyStun(otherStatus);
            Destroy(gameObject);
        }
    }
}
