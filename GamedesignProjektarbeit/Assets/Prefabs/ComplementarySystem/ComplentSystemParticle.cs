using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplentSystemParticle : MonoBehaviour
{
    public Sprite[] sprites;
    private StatusManager attachedObject;

    private void Update()
    {
        if(attachedObject == null)
        {
            transform.Rotate(0, 0, 360 * Time.deltaTime);
        }
          
    }
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        Destroy(gameObject, 15f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<StatusManager>() != null)
        {
            StatusManager otherStatus = collision.GetComponent<StatusManager>();
            if (otherStatus.faction == StatusManager.Faction.Enemy)
            {
                transform.parent = collision.transform;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().drag = 4;
                otherStatus.moveSpeedPenalty++;
                GetComponent<Collider2D>().enabled = false;
                attachedObject = otherStatus;

            }
        }

    }

    private void OnDestroy()
    {
        if(attachedObject != null)
        {
            attachedObject.moveSpeedPenalty--;
        }
      
    }



}
