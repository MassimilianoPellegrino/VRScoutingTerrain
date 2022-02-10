using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public GameObject pauseMenuUI;
   private bool mouseAttivo;

   void Update()
   {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
           if(GameIsPaused)
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
       mouseAttivo = !mouseAttivo;
       Cursor.visible = mouseAttivo;
       if (mouseAttivo)
        Cursor.lockState = CursorLockMode.Confined;
       else
        Cursor.lockState = CursorLockMode.Locked;
       pauseMenuUI.SetActive(false);
       Time.timeScale = 1f;
       GameIsPaused = false;
   }

   void Pause()
   {
       mouseAttivo = !mouseAttivo;
       Cursor.visible = mouseAttivo;
       if (mouseAttivo)
        Cursor.lockState = CursorLockMode.Confined;
       else
        Cursor.lockState = CursorLockMode.Locked;

       pauseMenuUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;

   }

   public void LoadMenu()
   {
     Time.timeScale = 1f;  
     SceneManager.LoadScene("StartMenu");
   }

   public void QuitGame()
   {
       Application.Quit();
       Debug.Log("Quitting");
   }
}
