using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnet : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private bool carnetIsVisible = false;

    private void Update()
    {
        if (!carnetIsVisible && Input.GetKeyDown(KeyCode.E))
        {
            Sho
        }
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[0]; 
    }

    void ShowCarnet()
    {
        
    }
    
    
}
