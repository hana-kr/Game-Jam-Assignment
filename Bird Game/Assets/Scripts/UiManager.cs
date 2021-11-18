using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Text CoinCount;
    public Text BirdCount;
    public EventSystemCustom eventSystem;
    public Player player;
    public Text gameOverTex;
    public Text WonText;
    public Button Restartbutton;

    void Start()
    {
        Restartbutton.gameObject.SetActive(false);
        WonText.gameObject.SetActive(false);
        gameOverTex.gameObject.SetActive(false);
        eventSystem.UpdatedCoins.AddListener(UpdateCoins);
        eventSystem.UpdatedBirds.AddListener(UpdateBirds);
        eventSystem.GameOver.AddListener(GameOverText);
        eventSystem.Win.AddListener(WinText);
    }
    public void WinText()
    {
        WonText.gameObject.SetActive(true);
    }

    public void GameOverText()
    {
        gameOverTex.gameObject.SetActive(true);
        Restartbutton.gameObject.SetActive(true);
    }
    public void UpdateCoins()
    {
        Debug.Log("UPDATE COINS");
        CoinCount.text = player.CoinCount.ToString() + " Coins Collected";

    }
    public void UpdateBirds()
    {
        Debug.Log("UPDATE BIRDS");
        BirdCount.text = player.BirdCount.ToString() + " Launched Birds";


    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
