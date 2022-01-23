using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int dna = 100;
    public static GameManager instance;
    public TextMeshProUGUI dnaText;



    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            SetDNAText(dna);
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UnitButton.PositionTargetedUnit();
        UnitButton.CheckForPlaceUnit();
    }

    public static Vector2 NormalizedDirection(Vector2 origin, Vector2 target)
    {
        Vector2 dir = (target - origin).normalized;
        return dir;
        // test
    }

    private void SetDNAText(int amount)
    {
        dnaText.text = amount.ToString();
    }
    public int Dna 
    { 
        get => dna;
        set 
        {
            SetDNAText(value);
            dna = value;
        }
    }
}
