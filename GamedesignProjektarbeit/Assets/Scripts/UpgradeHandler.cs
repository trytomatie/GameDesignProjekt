using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// By Christian Scherzer
/// </summary>
public class UpgradeHandler : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite sprite;
    private Vector2 normalSize;
    // Start is called before the first frame update
    void Start()
    {
        normalSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Opens Upgrade Menu
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        DescriptionManager.instance.OpenDescription(sprite, GetComponent<StatusManager>());
    }

    /// <summary>
    /// Increases Scale on enter
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = normalSize * 1.2f;
    }

    /// <summary>
    /// Decreases Scale on exit
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = normalSize;
    }
}
