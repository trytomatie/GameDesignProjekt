using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptMovingEnemy : MonoBehaviour
{

    private Rigidbody2D enemyRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(1, 0);
        enemyRigidbody.AddForce(movement);
    }
}
