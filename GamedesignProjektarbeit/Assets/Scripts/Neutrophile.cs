using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrophile : BasicTurretAI
{
    // Start is called before the first frame update

    private void Start()
    {
        myStatus = GetComponent<StatusManager>();

        turretAudioSource = GetComponent<AudioSource>();

        Invoke("KillCell", 60);
    }
    // Update is called once per frame
    void Update()
    {
        FindTarget();
        CheckAttack();
        upgradeText.text = myStatus.level.ToString();


    }
    
    /// <summary>
    /// Kills the Cell
    /// by Dilara Durmus
    /// </summary>
   void KillCell()
    {
        myStatus.ApplyDamage(10000);
    }
    
}
