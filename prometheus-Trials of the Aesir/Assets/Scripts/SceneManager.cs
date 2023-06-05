 using UnityEngine;
 using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
 {
 
     public void LoadLevel (string Map)
     {
         SceneManager.LoadScene (Map);
     }
     
     public void QuitRequest ()
     {
        Application.Quit();
    }
     
     public void LoadNextLevel (string Trial)
     {
        SceneManager.LoadScene (Trial);
    }
 }