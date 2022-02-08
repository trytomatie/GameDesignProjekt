using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public int movementSpeed = 1;
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

    /// <summary>
    /// Moves Enemy with a certain Speed
    /// by Shaina Milde
    /// </summary>
    public void MoveEnemy()
    {
        rb.velocity = direction * movementSpeed;
    }

    /// <summary>
    /// Closes Application
    /// by Dilara Durmus
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(0);
    }


}
