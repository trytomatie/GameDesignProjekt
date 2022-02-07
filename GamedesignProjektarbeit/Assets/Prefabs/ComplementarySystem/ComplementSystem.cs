using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplementSystem : MonoBehaviour
{
    public int cost = 10;
    public GameObject particle;

    private void Start()
    {
        Invoke("PurchaseComplementSystem",30);
    }
    public void PurchaseComplementSystem()
    {
        if (GameManager.instance.Dna >= cost)
        {
            GameManager.instance.Dna -= cost;
            InvokeRepeating("SpawnParticles", 0, 0.1f);
            Invoke("StopParticlesSpawn", 12);
        }
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
