using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;
public class RetryButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject play;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);

        PlayerPrefs.SetInt("Retry", 1);

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
