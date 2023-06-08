using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject playerPrefab;
    public GameObject pauseMenuUI;
    private static bool MenuExists;
    public GameObject BTLSYSTM;

    void Start()
    {
        if (!MenuExists)
        {
            MenuExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            
        }

    }
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        BTLSYSTM.SetActive(true);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        BTLSYSTM.SetActive(false);
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu2");
    }
    public void LoadMAP()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map");
        Destroy(gameObject);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}