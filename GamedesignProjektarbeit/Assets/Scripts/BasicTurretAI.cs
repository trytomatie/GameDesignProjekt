using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicTurretAI : MonoBehaviour
{

    public Transform target;
    protected StatusManager myStatus;
    private GameObject projectilePrefab;
    public GameObject[] projectilePrefabs;
    public float attackRadius = 4;
    public bool attackOnCooldown = false;

    public bool locksOnTarget = false;

    public AudioClip shootSound;
    public AudioClip attackSound;
    protected AudioSource makrophageAudioSource;
    protected AudioSource turretAudioSource;

    public TextMeshPro upgradeText;
    
    // Start is called before the first frame update
    void Start()
    {
        myStatus = GetComponent<StatusManager>();

        turretAudioSource = GetComponent<AudioSource>();
        makrophageAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        CheckAttack();

        upgradeText.text = myStatus.level.ToString();
    }

    protected void CheckAttack()
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
        myStatus.Stamina-= 2;
        projectilePrefab = projectilePrefabs[Random.Range(0, projectilePrefabs.Length)];
        GameObject go = Instantiate(projectilePrefab, transform.position - new Vector3(0,0,-10), Quaternion.identity);
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.Instanciate(myStatus, myStatus.damage, myStatus.projectileSpeed, target, locksOnTarget);
        attackOnCooldown = true;
        float attackCooldown =  Mathf.Clamp(1 / myStatus.Attackspeed,0.01f,100f);
        Invoke("AttackCooldown", attackCooldown);

        turretAudioSource.PlayOneShot(shootSound, 0.1f);
        
    }

    private void AttackCooldown()
    {
        attackOnCooldown = false;
    }

    

    protected bool FindTarget()
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
