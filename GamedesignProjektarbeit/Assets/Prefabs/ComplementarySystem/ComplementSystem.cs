using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplementSystem : MonoBehaviour
{
    public int cost = 10;
    public GameObject particle;
    public Animator fluid;

    public float duration;

    private void Start()
    {
        // Invoke("PurchaseComplementSystem",30);
    }
    public void PurchaseComplementSystem()
    {
        if (GameManager.instance.Dna >= cost && !fluid.GetBool("Animate"))
        {
            fluid.SetBool("Animate", true);
            GameManager.instance.Dna -= cost;
            InvokeRepeating("SpawnParticles", 0, 0.1f);
            Invoke("StopParticlesSpawn", duration);
            Invoke("ResetAnimation", duration);
        }
    }

    public void ResetAnimation()
    {
        fluid.SetBool("Animate", false);
    }
    public void StopParticlesSpawn()
    {
        CancelInvoke("SpawnParticles");
    }
    public  void SpawnParticles()
    {
        Instantiate(particle, transform.position + new Vector3(Random.Range(-100,100), 0,0), transform.rotation);
    }
}
