using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);

        PlayerPrefs.SetInt("Retry", 0);

        AdsHandler.Instance.ShowVideoAds();
    }
}
