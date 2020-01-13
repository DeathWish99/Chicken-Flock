using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyScore : MonoBehaviour, IPointerClickHandler
{

    public GameObject manager;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (manager.GetComponent<GameManager>().coin >= 15)
        {
            manager.GetComponent<GameManager>().score += 500;
            manager.GetComponent<GameManager>().coin -= 15;

            manager.GetComponent<GameManager>().coinText.text = manager.GetComponent<GameManager>().coin.ToString();

            PlayerPrefs.SetInt("Coins", manager.GetComponent<GameManager>().coin);
        }
    }
}
