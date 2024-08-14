using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject GameOverScreen;

    private void Awake()
    {
        isGameOver = false;
    }
    void Update()
    {
        if(isGameOver)
        {
            GameOverScreen.SetActive(true);
            }
    }
}
