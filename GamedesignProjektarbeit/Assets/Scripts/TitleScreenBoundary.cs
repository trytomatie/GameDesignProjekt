using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBoundary : MonoBehaviour
{
    public Vector2 multiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<TitleScreen>().direction = collision.gameObject.GetComponent<TitleScreen>().direction * multiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<TitleScreen>().direction = collision.gameObject.GetComponent<TitleScreen>().direction * multiplier;
    }
}
