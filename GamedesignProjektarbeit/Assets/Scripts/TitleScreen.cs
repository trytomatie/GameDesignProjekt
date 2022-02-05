using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public int movementSpeed = 1;
    public bool visible;
    public Vector2 direction;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
       MoveEnemy();  
    }

    public void MoveEnemy()
    {
        rb.velocity = direction * movementSpeed;
    }


}
