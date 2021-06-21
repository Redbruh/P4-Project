using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenue;
    public GameObject healthBar;

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Resume()
    {
        pauseMenue.SetActive(false);
        healthBar.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            healthBar.SetActive(false);
            pauseMenue.SetActive(true);
            
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        if (Input.GetButtonDown("Escape")) 
        {
            Cursor.lockState = CursorLockMode.None; 
        }
           
    }
}
