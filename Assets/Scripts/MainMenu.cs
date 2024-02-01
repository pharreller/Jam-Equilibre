using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Fade black;

    public void Start()
    {
        black.FadeInButton(true);
    }

    public IEnumerator Intro()
    {
        black.FadeInButton(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void LaunchGame()
    {
        StartCoroutine(Intro());
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
