using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LexiconScript : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI stats;
    public TextMeshProUGUI description;
    public Image image;
    public void OpenEntry(LexiconEntry entry)
    {
        title.text = entry.fullName;
        description.text = entry.fullDesciption;
        image.sprite = entry.sprite;
        StatusManager statusmanager = entry.prefab.GetComponent<StatusManager>();
        stats.text = "Name: " + statusmanager.entityName + "\n" +
    "Level: " + statusmanager.level + "->" + (statusmanager.level + 1) + "\n" +
    "Attackdamage: " + statusmanager.damage + "->" + statusmanager.damage + "\n" +
    "Attackspeed: " + statusmanager.Attackspeed + "->" + (statusmanager.Attackspeed).ToString(".00") + "\n" +
    "Cost: " + statusmanager.dnaCost;
    }
}
