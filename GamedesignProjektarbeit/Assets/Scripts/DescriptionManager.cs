using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// By Christian Scherzer
/// </summary>
public class DescriptionManager : MonoBehaviour
{

    public Image sprite;
    public TextMeshProUGUI descriptionText;
    public GameObject descriptionPanel;
    public StatusManager currentObject; // The current object of reference of the description
    public static DescriptionManager instance;


    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if(instance == null)
        {
            instance = this;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Chedcks if mouse was clicked outside of Description Manager
        if (Input.GetMouseButtonDown(0) && !RaycastMyself())
        {
            CloseDescription();
        }
    }
    /// <summary>
    /// Opens the Description Manager
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="statusmanager"></param>
    public void OpenDescription(Sprite sprite, StatusManager statusmanager)
    {
        currentObject = statusmanager;
        LoadDescription();

        descriptionPanel.SetActive(true);
    }

    /// <summary>
    /// Load the description Text
    /// </summary>
    public void LoadDescription()
    {
        sprite.sprite = currentObject.sprite;
        string descText = "Name: " + currentObject.entityName + "\n" +
            "Level: " + currentObject.level + "\n" +
            "Attackdamage: " + currentObject.damage + "\n" +
            "Attackspeed: " + currentObject.Attackspeed + "\n" +
            "Upgradecost: " + Mathf.CeilToInt((currentObject.upgradeCost));
        descriptionText.text = descText;
    }
    /// <summary>
    /// Close the Description
    /// </summary>
    public void CloseDescription()
    {
        descriptionPanel.SetActive(false);
    }

    /// <summary>
    /// Raycastes if cursor is over own ui element
    /// </summary>
    /// <returns></returns>
    public bool RaycastMyself()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current); // get pointer data from event system
        eventData.position = Input.mousePosition;                               // set Mouse Positon for data
        List<RaycastResult> raysastResults = new List<RaycastResult>();             
        EventSystem.current.RaycastAll(eventData, raysastResults);              // Raycast for UI
        foreach(RaycastResult res in raysastResults)                            // check all raycasts
        {
            if(gameObject == res.gameObject) // checks if raycasthit is this gameObject
            {
                return true;
            }
        }
        return false;
    }
}
