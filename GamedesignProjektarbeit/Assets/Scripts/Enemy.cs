using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{


    public AnimationClip dieAni;
    public AnimationClip attackAni;


    private Animator enemyAnimator;
    private Vector2 currentPos;
    private Vector2 lastPos;
    public Collider2D[] colliders;
    public GameObject dnaPrefab;

    private StatusManager myStatus;

    // Start is called before the first frame update
    void Start()
    {
        myStatus = GetComponent<StatusManager>();
        enemyAnimator = GetComponent<Animator>();       //get Animator Component (Markus)
        currentPos = new Vector2(transform.position.x, transform.position.y);   //set both Positions so there are not null (Markus)
        lastPos = new Vector2(transform.position.x, transform.position.y);
        myStatus.maxHp *= myStatus.level;
        myStatus.Hp = myStatus.maxHp;
        myStatus.dnaCost *= myStatus.level;

    }

    // Update is called once per frame
    void Update()
    {
        MovemenAni();
    }

    private void MovemenAni()
    {
        currentPos = new Vector2(transform.position.x, transform.position.y);           //set current Position (Markus)
        float walkingDistance = Mathf.Abs(Vector2.Distance(currentPos, lastPos));       //measure the distance between current and last position in order to get a movenent speed (Markus)

        enemyAnimator.SetFloat("movementSpeed", walkingDistance);                       //change movement speed im animator so it plays walking animation (Markus)

        lastPos = currentPos;                                                           //set last position to current position for next update (Markus)
    }

    private void OnTriggerEnter2D(Collider2D other)                                     
    {
        
        //Wenn ein Organ in reichweite kommt soll er Schaden nehmen
        if (other.gameObject.CompareTag("Organ"))                                       //Wenn der Gegner auf das Organ trifft soll Schaden ausgeteilt werden (Markus)
        {
            
            enemyAnimator.SetBool("isAttacking", true);                                 //Attack Animation des Gegners wird ausgeführt (Markus)
            Destroy(gameObject, attackAni.length);                                      //Nach der Animation wird der Gegner getoetet (Markus)

            var organScript = other.gameObject.GetComponent<Organ>();                   //bekomme das Scriptes des Organs und erteile Schaden (Markus)
            organScript.OrganTakeDamage(myStatus.damage);



            SpawnManager.instance.enemyCount = SpawnManager.instance.enemyCount - 1;    
            GetComponent<Collider2D>().enabled = false;
        }
    }
 

    public void DamageEvent()
    {
        enemyAnimator.SetTrigger("getDamage");                                          //if event is triggered play animation (Markus)
    }


    public void EnemyDeath()
    {
        enemyAnimator.SetBool("isAlive",false);         //play Death Animation (Markus)
        Destroy(gameObject, dieAni.length);             //ergaenzung der eines Sterbezeitraums damit die sterbeanimation ausgefuehrt werden kann (Markus)
        Instantiate(dnaPrefab, transform.position, dnaPrefab.transform.rotation); // Erzeugt ein DNA-Prefab bei Tod eines Gegners (Shaina)
        SpawnManager.instance.enemyCount = SpawnManager.instance.enemyCount - 1;

        foreach(Collider2D c in colliders)
        {
            c.enabled = false;
            
        }
        
        //GetComponent<Collider2D>().enabled = false;     
        if (GetComponent<FollowPath>() != null)
        {
            GetComponent<FollowPath>().enabled = false;
        }
             
        
    }
}
