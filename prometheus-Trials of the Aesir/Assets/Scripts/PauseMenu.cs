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
            Destroy(gameObject);
        }

    }
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                BTLSYSTM.SetActive(true);
                Resume();
            }
            else
            {
                
                BTLSYSTM.SetActive(false);
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu");
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