using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles unit Placement and Purchases 
/// by Christian Scherzer
/// </summary>
public class UnitButton : MonoBehaviour
{

    public GameObject einheit;
    public static bool holdingUnit;
    public static GameObject targetedUnit;
    public static bool placeDelay;

    public static UnityEvent unitAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if(holdingUnit && !placeDelay)
        {
            bool canPlace = true;
            RaycastHit2D[] raycastHits =  Physics2D.CircleCastAll(targetedUnit.transform.position, targetedUnit.GetComponent<CircleCollider2D>().radius * targetedUnit.transform.localScale.x, Vector2.zero);
            foreach(RaycastHit2D raycastHit in raycastHits)
            {
                if(raycastHit.collider.gameObject != targetedUnit && raycastHit.collider.gameObject.tag !="Enemy")
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
            Behaviour[] allCoponents = targetedUnit.GetComponents<Behaviour>();
            foreach (Behaviour component in allCoponents)
            {
                component.enabled = true;
            }
            targetedUnit.GetComponent<SpriteRenderer>().color = Color.white;
            targetedUnit = null;
            holdingUnit = false;

            unitAudio.Invoke();
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
            placeDelay = true;
            Invoke("DisableDelay", 0.3f);
            holdingUnit = true;
            targetedUnit = Instantiate(einheit, new Vector3(1000,0,0), Quaternion.identity);
        }
    }

    private void DisableDelay()
    {
        placeDelay = false;
    }

    /// <summary>
    /// Checks cost of Unit
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    private static bool CheckForCost(StatusManager unit)
    {
        if(GameManager.instance.Dna >= unit.dnaCost)
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
            GameManager.instance.Dna -= unitStatus.dnaCost;
            unitStatus.isActive = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
