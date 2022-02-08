using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public GameObject hpBar;
    public StatusManager status;

    // Update is called once per frame
    void Update()
    {
        // Updates hp bar (Christian)
        hpBar.transform.localScale = new Vector2( Mathf.Clamp01(status.hp / (float)status.maxHp) * 10, 1) ;
    }
}
