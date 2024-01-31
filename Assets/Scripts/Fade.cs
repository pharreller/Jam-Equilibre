using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public List<Image> UIImages = new List<Image>();
    public float Speed = 1;

    public void FadeInButton()
    {
        if (UIImages[0].color.a > 0.5f)
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
        float alpha = UIImages[0].color.a;

        while (alpha<1)
        {
            alpha += Time.deltaTime * Speed;
            for (int i = 0; i <UIImages.Count; i++)
            {
                UIImages[i].color = new Color(UIImages[i].color.r, UIImages[i].color.g, UIImages[i].color.b, alpha);
            }

            yield return null;
        }
        
        
        yield return null;
    }

    IEnumerator FadeOut()
    {
        float alpha = UIImages[0].color.a;

        while (alpha>0)
        {
            alpha += Time.deltaTime * Speed;
            for (int i = 0; i < UIImages.Count; i++)
            {
                UIImages[i].color = new Color(UIImages[i].color.r, UIImages[i].color.g, UIImages[i].color.b, alpha);
            }

            yield return null;
        }
        
        
        
        yield return null;
    }

}
