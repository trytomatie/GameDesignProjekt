using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// By Shaina Milde
/// </summary>
public class WinDialog : MonoBehaviour
{
    public Toggle point01;
    public Toggle point02;
    public Toggle point03;

    private Organ organ;

    // Start is called before the first frame update
    void Start()
    {
        organ = GameObject.FindObjectOfType<Organ>();
        float hpPercentage = organ.HealthPercentage();

        if (hpPercentage >= 100)
        {
            point01.isOn = true;
            point02.isOn = true;
            point03.isOn = true;
        }
        else if ( hpPercentage <= 100 && hpPercentage >= 50)
        {
            point01.isOn = true;
            point02.isOn = true;
        }

        else if (hpPercentage <= 50 && hpPercentage > 0)
        {
            point01.isOn = true;
        }
    }

}
