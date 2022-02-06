using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrophile : BasicTurretAI
{
    // Start is called before the first frame update

    private void Start()
    {
        myStatus = GetComponent<StatusManager>();
        Invoke("KillCell", 30);
    }
    // Update is called once per frame
    void Update()
    {
        FindTarget();
        CheckAttack();



    }
    
   void KillCell()
    {
        myStatus.Hp = 0;

    }
    
}
