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

        
    }
    private void Awake()
    {
      
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
        else
        {
           
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        BTLSYSTM.SetActive(true);
        Debug.Log("Game is resumed!");
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        BTLSYSTM.SetActive(false);
        Debug.Log("Game is Paused!");
    }

    public void LoadMenu()

    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu2");
        BTLSYSTM.SetActive(true);
        Debug.Log("Menu LOADED");
    }
    public void LoadMAP()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map");
        BTLSYSTM.SetActive(true);
        Debug.Log("MAP LOADED");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
        Debug.Log("Quit");
    }
}