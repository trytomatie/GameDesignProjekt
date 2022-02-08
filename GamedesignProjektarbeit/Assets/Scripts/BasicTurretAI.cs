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

    /// <summary>
    /// Checks for Attacks
    /// by Christian Scherzer
    /// </summary>
    protected void CheckAttack()
    {
        if (target != null && Vector3.Distance(target.transform.position, transform.position) < attackRadius && !attackOnCooldown)
        {
            // Attack
            ShootProjectile();
        }
    }

    /// <summary>
    /// Shoots Projectile
    /// by Christian Scherzer, Dilara Durmus and Shaina Milde
    /// </summary>
    private void ShootProjectile()
    {
        myStatus.Stamina-= 2;                                                                                                   // decreases stamina by fixed amount
        projectilePrefab = projectilePrefabs[Random.Range(0, projectilePrefabs.Length)];                                        // chooses random projectile prefab
        GameObject go = Instantiate(projectilePrefab, transform.position - new Vector3(0,0,-10), Quaternion.identity);
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.Initialize(myStatus, myStatus.damage, myStatus.projectileSpeed, target, locksOnTarget);
        attackOnCooldown = true;
        float attackCooldown =  Mathf.Clamp(1 / myStatus.Attackspeed,0.01f,100f);                                               // sets attack cooldown according to attack speed, kept at 100 attacks per second
        Invoke("AttackCooldown", attackCooldown);

        turretAudioSource.PlayOneShot(shootSound, 0.1f);  
    }

    /// <summary>
    /// Ressets Attack Cooldown
    /// by Christian Scherzer
    /// </summary>
    private void AttackCooldown()
    {
        attackOnCooldown = false;
    }

    
    /// <summary>
    /// Finds a target
    /// </summary>
    /// <returns></returns>
    protected bool FindTarget()
    {
        // Get all targets available
        StatusManager[] targets = GameObject.FindObjectsOfType<StatusManager>(true);
        float distance = 1000;
        // Search all targets
        foreach (StatusManager target in targets)
        {
            // Ignore targets from own faction
            if(target.faction == myStatus.faction)
            {
                continue;
            }
            float targetDistance = Vector2.Distance(transform.position, target.transform.position);
            // Asign target that is closest to me as main target
            if (targetDistance < distance && target.GetComponent<StatusManager>().Hp > 0)
            {
                distance = targetDistance;
                this.target = target.transform;
            }
        }
        // Returns if target was found or not
        if (target != null)
        {
            return true;
        }
        return false;
    }


}
