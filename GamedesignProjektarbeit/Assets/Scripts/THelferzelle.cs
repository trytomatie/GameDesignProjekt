using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THelferzelle : MonoBehaviour
{
    public float radius;
    private StatusManager myStatus;
    public GameObject influenceRadius;

    public AudioClip buffSound;
    public AudioSource helperCellAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GiveStamina", 0, 1f);
        myStatus = GetComponent<StatusManager>();
        influenceRadius.transform.localScale = new Vector3(1, 1, 1) * radius;

        helperCellAudioSource = GetComponent<AudioSource>();
        helperCellAudioSource.PlayOneShot(buffSound, 0.1f);
    }

    private void GiveStamina()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject go in array)
        {
            if(Vector2.Distance(go.transform.position,transform.position) < radius)
            {
                StatusManager otherStatus = go.GetComponent<StatusManager>();
                if(otherStatus.stamina < otherStatus.maxStamina)
                {
                    go.GetComponent<StatusManager>().stamina += myStatus.damage;
                }

            }
        }
    }

}
