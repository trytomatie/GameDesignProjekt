using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    public GameObject hpBar;
    public StatusManager status;

    // Update is called once per frame
    void Update()
    {
        // Updates the Stamina bar
        hpBar.transform.localScale = new Vector2(Mathf.Clamp01(status.Stamina / (float)status.maxStamina) * 10, 1);
    }
}
