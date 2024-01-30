using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    [SerializeField] private int pageNb;
    private Carnet carnetScript;

    void Start()
    {
        carnetScript = FindObjectOfType<Carnet>();
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            carnetScript.pagesArray[pageNb]= GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Page ramassée");
            gameObject.SetActive(false);
        }
    }
}
