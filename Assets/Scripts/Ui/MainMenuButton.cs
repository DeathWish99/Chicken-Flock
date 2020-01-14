using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;


public class MainMenuButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);

        PlayerPrefs.SetInt("Retry", 0);

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
