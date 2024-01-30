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
    public bool carnetIsVisible = false;
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
                if (rightPageVisible < 5)
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
    
    public void ToggleShowCarnet()
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
        /*if (rightPageVisible == 1)
        {
            attach.enabled = true;
            leftPage.enabled=false;
        }
        else
        {*/
        leftPage.sprite = pagesArray[rightPageVisible-1]; 
        Show(leftPage);
        /*}
        if (rightPageVisible == 7)
        {
            attach.enabled = true;
            rightPage.enabled=false;
        }
        else
        {*/
        rightPage.sprite = pagesArray[rightPageVisible];
        Show(rightPage);
    }

    void Show(Image page)
    {
        if (page.sprite != null)
        {
            page.enabled = true; 
        }
        else
        {
            page.enabled = false; //mettre une page de base
        }
    }
}
