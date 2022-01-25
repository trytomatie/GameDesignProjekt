using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeButton : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;

    public float damageMultiplier = 1.5f;
    public float attackSpeedGain = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RaycastMyself())
        {
            HoverUpgrade();
        }
        else
        {
            DescriptionManager.instance.LoadDescription();
        }
    }

    public void Upgrade()
    {
        StatusManager statusmanager = DescriptionManager.instance.currentObject;
        int upgradeCost = Mathf.CeilToInt(statusmanager.dnaCost * 2f);
        if (CheckForCost(upgradeCost))
        {

            statusmanager.damage = Mathf.CeilToInt(statusmanager.damage * damageMultiplier);
            statusmanager.attackspeed = statusmanager.attackspeed += attackSpeedGain;
            statusmanager.dnaCost = upgradeCost;
            GameManager.instance.Dna -= upgradeCost;
            statusmanager.level++;
        }

    }

    public void HoverUpgrade()
    {
        StatusManager statusmanager = DescriptionManager.instance.currentObject;
        string descText = "Name: " + statusmanager.entityName + "\n" +
    "Level: " + statusmanager.level + "->" + (statusmanager.level + 1) + "\n" +
    "Attackdamage: " + statusmanager.damage + "->" + statusmanager.damage * damageMultiplier + "\n" +
    "Attackspeed: " + statusmanager.attackspeed + "->" + (statusmanager.attackspeed + attackSpeedGain).ToString(".00") + "\n" +
    "Upgradecost: " + statusmanager.dnaCost * 2f + "->" + statusmanager.dnaCost * 2 * 2;
        descriptionText.text = descText;
    }

    public bool RaycastMyself()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        foreach (RaycastResult res in raysastResults)
        {
            if (gameObject == res.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks cost of Unit
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    private static bool CheckForCost(int cost)
    {
        if (GameManager.instance.Dna >=cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
