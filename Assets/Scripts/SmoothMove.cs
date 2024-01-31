using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    private Vector2 xCoords;
    private Vector2 yCoords;
    public float timing = 0.5f;

    private float elapsedTime = 0f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / timing);

            transform.position = Vector3.Lerp(xCoords, yCoords, t);

            if (t >= 1f)
            {
                isMoving = false;
                elapsedTime = 0f;
            }
        }
    }

    public void FromTo(Vector2 x, Vector2 y,float time)
    {
        timing = time;
        xCoords = x;
        yCoords = y;
        isMoving = true;
    }
}
