using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnet : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[0]; 
    }
}
