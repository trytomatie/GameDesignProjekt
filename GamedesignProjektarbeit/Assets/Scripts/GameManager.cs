using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int dna = 100;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
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
}
