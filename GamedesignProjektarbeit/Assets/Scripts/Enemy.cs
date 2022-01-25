using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
        SpawnManager.instance.enemyCount = SpawnManager.instance.enemyCount - 1;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<FollowPath>().enabled = false;

    }
}
