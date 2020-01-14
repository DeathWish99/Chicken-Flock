using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public Text coinText;

    public GameObject gameOver;
    public GameObject play;

    public bool speedBuff = false;
    public bool coinBuff = false;
   

    public float score;

    public int coin = 0;
    public int coinMultiplier = 1;
    private int retry;
    private void Awake()
    {
        Time.timeScale = 0;
        coin = PlayerPrefs.GetInt("Coins");
        coinText.text = coin.ToString();

        retry = PlayerPrefs.GetInt("Retry");

        if (retry == 1)
        {
            play.GetComponent<Play>().StartGame();
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale > 0)
        {
            score++;
            scoreText.text = score.ToString() + " M";
        }
        coinText.text = coin.ToString();
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt("Coins", coin);
        gameOver.SetActive(true);
    }

}
