using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    
    public float Speed = 1;

    public void FadeInButton(bool black)
    {
        if (black)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
        } //pas le temps lol

        if (GetComponent<Image>().color.a < 0.5f)
        {
          StartCoroutine(FadeIN());  
        }
        else
        { 
            StartCoroutine(FadeOut());
        }
        
    }
    
    
    IEnumerator FadeIN()
    {
        Debug.Log("fadein"+GetComponent<Image>().color.a);
        float alpha = GetComponent<Image>().color.a;

        while (alpha<1)
        {
            alpha += Time.deltaTime * Speed;
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, alpha);
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeOut()
    {
        Debug.Log("fadeout"+GetComponent<Image>().color.a);
        float alpha = GetComponent<Image>().color.a;

        while (alpha>0)
        {
            alpha -= Time.deltaTime * Speed;
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, alpha);
            yield return null;
        }
        yield return null;
    }

}
