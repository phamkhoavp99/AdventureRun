using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    private bool pause = false;
    public GameObject pauseUI;

    void Start()
    {
        pauseUI.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if(pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void resume()
    {
        pause = false;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quit()
    {
        Application.Quit();
    }
}
