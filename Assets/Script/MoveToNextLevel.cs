using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int MainMenuIndex = 0; // Set this to the build index of your LevelSelection scene

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 11) 
            {
                Debug.Log("You Completed ALL Levels");

                // Show Win Screen or something.
            }
            else
            {
                // Load level selection instead of the next level
                SceneManager.LoadScene(MainMenuIndex);

                // Setting Int for Index
                if (MainMenuIndex > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", MainMenuIndex);
                }
            }
        }
    }
}
