using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenue;
   

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Resume()
    {
        pauseMenue.SetActive(false);        
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {

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

        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetButtonDown("Cancel"))
            {
                Cursor.lockState = CursorLockMode.Confined;
            }            
        }           
    }
}
