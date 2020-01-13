using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuySpeed : MonoBehaviour, IPointerClickHandler
{
    public GameObject chicken;
    public GameObject manager;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(manager.GetComponent<GameManager>().coin >= 55 && !manager.GetComponent<GameManager>().speedBuff)
        {
            chicken.GetComponent<PlayerController>().speed *= 2;
            manager.GetComponent<GameManager>().coin -= 55;

            manager.GetComponent<GameManager>().coinText.text = manager.GetComponent<GameManager>().coin.ToString();
            manager.GetComponent<GameManager>().speedBuff = true;

            PlayerPrefs.SetInt("Coins", manager.GetComponent<GameManager>().coin);
        }
            
    }
}
