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
        if (Input.GetKeyDown(KeyCode.Escape)&& Time.timeScale == 1f )
        {
            ToggleMenu(pauseMenuUI);
        }
    }

    public void ToggleMenu(GameObject ui)
    {
        Cursor.lockState = (ui.activeSelf) ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
        
        player.playerCanMove = !player.playerCanMove;
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf)
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
        Time.timeScale = (ui.activeSelf) ? 0f : 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        //endgame then credits in the menu
    }
    
}
