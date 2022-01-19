using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles unit Placement and Purchases 
/// by Christian Scherzer
/// </summary>
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
        print(targetedUnit);
    }

    /// <summary>
    /// Moves Unit to Curosr
    /// </summary>
    public static void PositionTargetedUnit()
    {
        if(targetedUnit != null)
        {
            targetedUnit.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    /// <summary>
    /// Check Unit Placement
    /// </summary>
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
            if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
            {
                EraseUnit();
            }

        }
    }

    /// <summary>
    /// Erases Unit
    /// </summary>
    private static void EraseUnit()
    {
        holdingUnit = false;
        Destroy(targetedUnit);
        targetedUnit = null;
    }

    /// <summary>
    /// Places Unit 
    /// </summary>
    private static void PlaceUnit()
    {
        if(PurchaseUnit(targetedUnit))
        {
            targetedUnit = null;
            holdingUnit = false;
        }
        else
        {
            EraseUnit();
        }

        print("Unit Placed");
    }

    /// <summary>
    /// Selects Unit
    /// </summary>
    public void SelectUnit()
    {
        if(holdingUnit == false)
        {
            holdingUnit = true;
            targetedUnit = Instantiate(einheit, new Vector3(1000,0,0), Quaternion.identity);
        }
    }

    /// <summary>
    /// Checks cost of Unit
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    private static bool CheckForCost(StatusManager unit)
    {
        if(GameManager.instance.dna >= unit.dnaCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Purchases Unit and sets it active
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    private static bool PurchaseUnit(GameObject unit)
    {
        StatusManager unitStatus = unit.GetComponent<StatusManager>();
        if (CheckForCost(unitStatus))
        {
            GameManager.instance.dna -= unitStatus.dnaCost;
            unitStatus.isActive = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}