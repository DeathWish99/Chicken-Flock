using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyCoin : MonoBehaviour, IPointerClickHandler
{
    public GameObject manager;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (manager.GetComponent<GameManager>().coin >= 25 && !manager.GetComponent<GameManager>().coinBuff)
        {
            manager.GetComponent<GameManager>().coin -= 25;
            manager.GetComponent<GameManager>().coinMultiplier = 2;
            manager.GetComponent<GameManager>().coinText.text = manager.GetComponent<GameManager>().coin.ToString();
            manager.GetComponent<GameManager>().coinBuff = true;
            PlayerPrefs.SetInt("Coins", manager.GetComponent<GameManager>().coin);
        }

    }
}
