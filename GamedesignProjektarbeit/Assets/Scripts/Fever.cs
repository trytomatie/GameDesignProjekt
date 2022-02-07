using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public CameraShake cameraShake;
    public float duration = 12;
    public int cost = 50;
    public int fevorStrength = 1;
    public Animator fevorVfx;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchaseFeverSystem()
    {
        if (GameManager.instance.Dna >= cost)
        {
            fevorVfx.SetBool("Animate", true);
            StartCoroutine(cameraShake.Shake(duration, 0.5f));
            GameManager.instance.Dna -= cost;
            InvokeRepeating("FevorEffect", 0, 1.5f);
            Invoke("ResetAnimation", duration);
        }
    }

    private void ResetAnimation()
    {
        fevorVfx.SetBool("Animate", false);
        CancelInvoke("FevorEffect");
    }
    private void FevorEffect()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemys)
        {
            enemy.GetComponent<StatusManager>().ApplyDamage(fevorStrength * enemy.GetComponent<StatusManager>().level);
        }
        GameObject.FindObjectOfType<Organ>().CurrentHealth -= 4;
    }
}
