using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Play : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public List<GameObject> activateThese;
    public List<GameObject> deactivateThese;
    public GameObject flock;
    public void OnPointerClick(PointerEventData eventData)
    {
        StartGame();
    }

    public void StartGame()
    {
        foreach (GameObject obj in activateThese)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in deactivateThese)
        {
            obj.SetActive(false);
        }

        flock.GetComponent<Flock>().SpawnFlock();

        Time.timeScale = 1;
    }
}
