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
        string descText = "Name: " + statusmanager.entityName +"\n"+
            "Level: " + statusmanager.level + "\n" +
            "Attackdamage: " + statusmanager.damage + "\n" +
            "Attackspeed: " + statusmanager.attackspeed + "\n" +
            "Upgradecost: " + statusmanager.dnaCost * 1.3f;
        descriptionText.text = descText;
        descriptionPanel.SetActive(true);
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
