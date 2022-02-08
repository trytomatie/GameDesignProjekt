using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// By Christian Scherzer
/// </summary>
public class UpgradeButton : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    public Image sprite;

    public float damageMultiplier = 1.125f;
    public float attackSpeedGain = 0.125f;
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

    /// <summary>
    /// Upgrade Unit
    /// </summary>
    public void Upgrade()
    {
        StatusManager statusmanager = DescriptionManager.instance.currentObject;
        int upgradeCost = UpgradeCost();
        if (CheckForCost(upgradeCost))
        {

            statusmanager.damage = Mathf.CeilToInt(statusmanager.damage * damageMultiplier) + 1;
            statusmanager.baseAttackspeed = statusmanager.baseAttackspeed += attackSpeedGain;
            statusmanager.upgradeCost = Mathf.CeilToInt((statusmanager.upgradeCost) * 2.5f);
            GameManager.instance.Dna -= upgradeCost;
            statusmanager.level++;
        }

    }

    private int UpgradeCost()
    {
        StatusManager statusmanager = DescriptionManager.instance.currentObject;
        return Mathf.CeilToInt((statusmanager.upgradeCost));
    }

    /// <summary>
    /// Shows Statuschanges when hoverd over Upgradebutton
    /// </summary>
    public void HoverUpgrade()
    {

        StatusManager statusmanager = DescriptionManager.instance.currentObject;
        string descText = "Name: " + statusmanager.entityName + "\n" +
    "Level: " + statusmanager.level + "->" + (statusmanager.level + 1) + "\n" +
    "Attackdamage: " + statusmanager.damage + "->" + statusmanager.damage * damageMultiplier + "\n" +
    "Attackspeed: " + statusmanager.Attackspeed + "->" + (statusmanager.Attackspeed + attackSpeedGain).ToString(".00") + "\n" +
    "Upgradecost: " + UpgradeCost() + "->" + Mathf.CeilToInt((statusmanager.upgradeCost) * 2.5f);
        descriptionText.text = descText;
    }

    /// <summary>
    /// Raycast myself
    /// </summary>
    /// <returns></returns>
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
