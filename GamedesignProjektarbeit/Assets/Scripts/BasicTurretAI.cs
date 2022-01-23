using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretAI : MonoBehaviour
{

    public Transform target;
    private StatusManager myStatus;
    public GameObject projectilePrefab;
    public float attackRadius = 4;
    public bool attackOnCooldown = false;

    public bool locksOnTarget = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myStatus = GetComponent<StatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        CheckAttack();
    }

    private void CheckAttack()
    {
        if (target != null && Vector3.Distance(target.transform.position, transform.position) < attackRadius && !attackOnCooldown)
        {
            // Attack
            ShootProjectile();
        }
        else
        {
            
        }
    }

    private void ShootProjectile()
    {
        GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.Instanciate(myStatus, myStatus.damage, myStatus.projectileSpeed, target, locksOnTarget);
        attackOnCooldown = true;
        float attackCooldown =  Mathf.Clamp(1 / myStatus.attackspeed,0.01f,100f);
        Invoke("AttackCooldown", attackCooldown);
        
    }

    private void AttackCooldown()
    {
        attackOnCooldown = false;
    }

    

    private bool FindTarget()
    {
        StatusManager[] targets = GameObject.FindObjectsOfType<StatusManager>(true);
        float distance = 1000;
        foreach (StatusManager target in targets)
        {
            if(target.faction == myStatus.faction)
            {
                continue;
            }
            float targetDistance = Vector2.Distance(transform.position, target.transform.position);
            if (targetDistance < distance && target.GetComponent<StatusManager>().Hp > 0)
            {
                distance = targetDistance;
                this.target = target.transform;
            }
        }
        if (target != null)
        {
            return true;
        }
        return false;
    }


}
