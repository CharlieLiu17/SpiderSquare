using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject cam;
    public GameObject score;
    public GameObject optionMenu;

    public GameObject pauseMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!optionMenu.activeSelf)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            
        }    
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        score.SetActive(true);
        if (cam.GetComponent<AudioSource>() != null)
        {
            cam.GetComponent<AudioSource>().Play();
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        score.SetActive(false);
        if (cam.GetComponent<AudioSource>() != null)
        {
            cam.GetComponent<AudioSource>().Pause();
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OptionsMenu()
    {
        optionMenu.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void BackMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
        CancelInvoke();
    }
}
