using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public GameObject pauseMenuScreen;
    public Gate gate; // Reference to the Gate script attached to the gate GameObject.

    void Start()
    {
        numberOfCoins = 0;
    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString();

        // Check if the coin count reaches 5 and destroy the gate.
        if (numberOfCoins >= 5 && gate != null)
        {
            AudioManager.instance.Play("Gate");
            gate.DestroyGate();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
