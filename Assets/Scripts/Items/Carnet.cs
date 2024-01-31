using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carnet : MonoBehaviour
{
    public Image cover;
    public Image attach;
    public Image leftVirgin;
    public Image rightVirgin;
    public Image leftPage;
    public Image rightPage;
    public Sprite[] pagesArray;
    public bool carnetIsVisible = false;
    private int rightPageVisible = 1;

    public GameObject pageUiprefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ToggleShowCarnet());
        }
        
        if (carnetIsVisible)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (rightPageVisible > 1)
                {
                    rightPageVisible -= 2;
                    GetComponent<AudioManager>().StartCoroutine("PlayRandomAudio");
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
                    GetComponent<AudioManager>().StartCoroutine("PlayRandomAudio");
                }
                else
                {
                    Debug.Log("No pages after");
                }
                TurnPage();
            }
        }
    }
    
    public IEnumerator ToggleShowCarnet()
    {
        if (carnetIsVisible)
        {
            GetComponent<SmoothMove>().FromTo(new Vector2(0,0), new Vector2(0,-1000),0.2f);
            yield return new WaitForSeconds(0.2f);
            carnetIsVisible = false;
            cover.enabled = false;
            attach.enabled = false;
            leftVirgin.enabled = false;
            rightVirgin.enabled = false;
            leftPage.enabled = false;
            rightPage.enabled = false;
        }
        else
        { 
            
            carnetIsVisible = true;
            attach.enabled = true;
            cover.enabled = true;
            leftVirgin.enabled = true;
            rightVirgin.enabled = true;
            TurnPage();
            GetComponent<SmoothMove>().FromTo(new Vector2(0,-1000),new Vector2(0,0),0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void TurnPage()
    {
        leftPage.sprite = pagesArray[rightPageVisible-1];
        rightPage.sprite = pagesArray[rightPageVisible];
        leftVirgin.color= new Color(1,1,1,0.95f);
        rightVirgin.color= new Color(1,1,1,0.95f);
        leftVirgin.color= new Color(1,1,1,1);
        rightVirgin.color= new Color(1,1,1,1);
        Show(leftPage);
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

    public void PageAnim(Sprite page)
    {
        pageUiprefab.GetComponent<Image>().sprite = page;
        Instantiate(pageUiprefab, transform);
    }
}
