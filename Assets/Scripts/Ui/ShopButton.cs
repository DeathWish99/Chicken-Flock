using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject shopPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        shopPanel.SetActive(true);
    }
}
