using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{

    public Image sprite;
    public TextMeshProUGUI descriptionText;
    public GameObject descriptionPanel;
    public StatusManager currentObject;
    public static DescriptionManager instance;


    // Start is called before the first frame update
    void Start()
    {
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
        
        if (Input.GetMouseButtonDown(0) && !RaycastMyself())
        {
            CloseDescription();
        }
    }

    public void OpenDescription(Sprite sprite, StatusManager statusmanager)
    {
        currentObject = statusmanager;
        LoadDescription();

        descriptionPanel.SetActive(true);
    }

    public void LoadDescription()
    {
        sprite.sprite = currentObject.sprite;
        string descText = "Name: " + currentObject.entityName + "\n" +
            "Level: " + currentObject.level + "\n" +
            "Attackdamage: " + currentObject.damage + "\n" +
            "Attackspeed: " + currentObject.Attackspeed + "\n" +
            "Upgradecost: " + currentObject.dnaCost * 2f;
        descriptionText.text = descText;
    }

    public void CloseDescription()
    {
        descriptionPanel.SetActive(false);
    }

    public bool RaycastMyself()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        foreach(RaycastResult res in raysastResults)
        {
            if(gameObject == res.gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
