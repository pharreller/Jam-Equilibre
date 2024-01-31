using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PageAddedAnim : MonoBehaviour
{
    private Vector3 dest;

    private float t=0.01f;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position - new Vector3(0,150,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != dest)
        {
            t *= 1.1f;
            transform.position = Vector3.Lerp(transform.position, dest,t);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
