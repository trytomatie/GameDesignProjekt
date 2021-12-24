using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretAI : MonoBehaviour
{

    public StatusManager target;
    private StatusManager myStatus;
    // Start is called before the first frame update
    void Start()
    {
        myStatus = GetComponent<StatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        StatusManager otherStatus = collision.gameObject.GetComponent<StatusManager>();
        if (otherStatus != null && otherStatus.faction != myStatus.faction)
        {
            ApplyDamage(otherStatus);
        }
    }

}
