using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{

    public GameObject einheit;
    public static bool holdingUnit;
    public static GameObject targetedUnit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void PositionTargetedUnit()
    {
        if(targetedUnit != null)
        {
            targetedUnit.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public static void CheckForPlaceUnit()
    {
        if(holdingUnit)
        {
            bool canPlace = true;
            RaycastHit2D[] raycastHits =  Physics2D.CircleCastAll(targetedUnit.transform.position, targetedUnit.GetComponent<CircleCollider2D>().radius * targetedUnit.transform.localScale.x, Vector2.zero);
            foreach(RaycastHit2D raycastHit in raycastHits)
            {
                if(raycastHit.collider.gameObject != targetedUnit)
                {
                    canPlace = false;
                }
            }
            if(Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceUnit();
            }

        }
    }

    static void PlaceUnit()
    {
        targetedUnit = null;
        holdingUnit = false;
        print("unit Placed");
    }

    public void SelectUnit()
    {
        if(holdingUnit == false)
        {
            holdingUnit = true;
            targetedUnit = Instantiate(einheit, new Vector3(1000,0,0), Quaternion.identity);
            
        }
    }
}
