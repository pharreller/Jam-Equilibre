using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public PlayerController player;
    public GameObject carnet;
    public VideoClip introVideo;
    public VideoClip outroVideo;
    private VideoPlayer vp;
    public Fade black;
    public GameObject control;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        black.FadeInButton(true);
        StartCoroutine(PlayVideo(introVideo,2f));
    }

    IEnumerator PlayVideo(VideoClip video, float delay)
    {
        player.playerCanMove = false;
        yield return new WaitForSeconds(delay*3);
        black.FadeInButton(false);
        yield return new WaitForSeconds(delay);
        control.SetActive(false);
        vp = GetComponent<VideoPlayer>();
        vp.clip = video;
        
        
        //Time.timeScale = 0f;
        Debug.Log("Debut video");
        vp.Play();
        yield return new WaitForSeconds(0.5f);
        black.FadeInButton(true);
        
        while (vp.frame != (long)vp.frameCount-1)
        {
            yield return null;
        }
        black.FadeInButton(true);
        Debug.Log("Fin video");
        vp.Stop();
        
        //Time.timeScale = 1f;
        
        if (vp.clip == outroVideo)
        {
            BackToMenu();
            player.playerCanMove = false;
        }
        else
        {
            // Camera Keanu Reevese
            player.playerCanMove = true;
        }
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
                carnet.GetComponent<Carnet>().StartCoroutine("ToggleShowCarnet");
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
        black.FadeInButton(false);
        StartCoroutine(PlayVideo(outroVideo,2f));
    }
}
