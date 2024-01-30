using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnet : MonoBehaviour
{
    public SpriteRenderer coverRenderer;
    public SpriteRenderer leftPageRenderer;
    public SpriteRenderer rightPageRenderer;
    public Sprite[] pagesArray;
    private bool carnetIsVisible = false;
    private int leftPageVisible = 0;

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
                if (leftPageVisible > 0)
                {
                    leftPageVisible -= 1;
                }
                else
                {
                    Debug.Log("No pages before");
                }

                TurnPage();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (leftPageVisible < 3)
                {
                    leftPageVisible += 1;
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
            coverRenderer.enabled = false;
            leftPageRenderer.enabled = false;
            rightPageRenderer.enabled = false;
        }
        else
        { 
            carnetIsVisible = true;
            coverRenderer.enabled = true;
            leftPageRenderer.enabled = true;
            rightPageRenderer.enabled = true;
        }
    }

    void TurnPage()
    {
        leftPageRenderer.sprite = pagesArray[leftPageVisible];
        rightPageRenderer.sprite = pagesArray[leftPageVisible+1];
    }
    
    
}
