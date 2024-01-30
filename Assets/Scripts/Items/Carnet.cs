using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carnet : MonoBehaviour
{
    public Image cover;
    public Image attach;
    public Image leftPage;
    public Image rightPage;
    public Sprite[] pagesArray;
    private bool carnetIsVisible = false;
    private int rightPageVisible = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleShowCarnet();
        }
        
        if (carnetIsVisible)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (rightPageVisible > 1)
                {
                    rightPageVisible -= 2;
                }
                else
                {
                    Debug.Log("No pages before");
                }

                TurnPage();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (rightPageVisible < 7)
                {
                    rightPageVisible += 2;
                }
                else
                {
                    Debug.Log("No pages after");
                }
                TurnPage();
            }
        }
    }
    
    void ToggleShowCarnet()
    {
        if (carnetIsVisible)
        {
            carnetIsVisible = false;
            cover.enabled = false;
            attach.enabled = false;
            leftPage.enabled = false;
            rightPage.enabled = false;
        }
        else
        { 
            carnetIsVisible = true;
            attach.enabled = true;
            cover.enabled = true;
            TurnPage();
        }
    }

    void TurnPage()
    {
        //Debug.Log(rightPageVisible);
        if (rightPageVisible == 1)
        {
            attach.enabled = true;
            leftPage.enabled=false;
        }
        else
        {
            leftPage.enabled=true;
            leftPage.sprite = pagesArray[rightPageVisible-1];
        }
        if (rightPageVisible == 7)
        {
            attach.enabled = true;
            rightPage.enabled=false;
        }
        else
        {
            rightPage.enabled=true;
            rightPage.sprite = pagesArray[rightPageVisible];
        }
    }
}
