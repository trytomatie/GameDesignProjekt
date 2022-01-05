using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
