using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public PlayerController player;
    public GameObject carnet;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        ToggleMouse();
        player.playerCanMove = !player.playerCanMove;
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        if (!pauseMenuUI.activeSelf)
        {
            if (carnet.GetComponent<Carnet>().carnetIsVisible)
            {
                carnet.GetComponent<Carnet>().ToggleShowCarnet();
            }
            carnet.SetActive(true);
        }
        else
        {
            
            carnet.SetActive(false);
        }
        Time.timeScale = (pauseMenuUI.activeSelf) ? 0f : 1f;
    }

    public void BackToMenu()
    {
        //SceneManager.LoadScene(0);
    }

    void ToggleMouse()
    {
        Cursor.lockState = (pauseMenuUI.activeSelf) ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
    }
    
}
