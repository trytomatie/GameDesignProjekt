using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBoundary : MonoBehaviour
{
    public Vector2 multiplier;

    /// <summary>
    /// Checks for collision for title screen bacteria and virus
    /// </summary>
    /// <param name="collision"></param>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<TitleScreen>().direction = collision.gameObject.GetComponent<TitleScreen>().direction * multiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<TitleScreen>().direction = collision.gameObject.GetComponent<TitleScreen>().direction * multiplier;
    }
}
