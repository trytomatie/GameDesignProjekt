using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public AnimationClip dieAni;

    private Animator enemyAnimator;
    private Vector2 currentPos;
    private Vector2 lastPos;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();       //get Animator Component
        currentPos = new Vector2(transform.position.x, transform.position.y);   //set both Positions so there are not null
        lastPos = new Vector2(transform.position.x, transform.position.y);      
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = new Vector2(transform.position.x, transform.position.y);           //set current Position
        float walkingDistance = Mathf.Abs(Vector2.Distance(currentPos, lastPos));       //measure the distance between current and last position in order to get a movenent speed

        enemyAnimator.SetFloat("movementSpeed", walkingDistance);                       //change movement speed im animator so it plays walking animation

        lastPos = currentPos;                                                           //set last position to current position for next update
    }

    public void DamageEvent()
    {
        enemyAnimator.SetTrigger("getDamage");                                          //if event is triggered play animation
    }


    public void EnemyDeath()
    {
        enemyAnimator.SetBool("isAlive",false);         //play Death Animation (Markus)
        Destroy(gameObject, dieAni.length);             //ergaenzung der eines Sterbezeitraums damit die sterbeanimation ausgefuehrt werden kann (Markus)

        SpawnManager.instance.enemyCount = SpawnManager.instance.enemyCount - 1;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<FollowPath>().enabled = false;
        
    }
}
