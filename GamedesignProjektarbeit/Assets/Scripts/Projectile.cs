using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public StatusManager origin;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
