using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Page : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }
}
