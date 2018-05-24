using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    bool isPaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy == false)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            
        }
    }
}
