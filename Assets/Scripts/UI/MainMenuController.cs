using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        string currentLevel = PlayerPrefs.GetString("CURRENT_LEVEL", "GamePlay");
        SceneManager.LoadScene(currentLevel);
    }
}
