using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Background : MonoBehaviour
{
    public float speedMove = 4f;
    public float startPosition = 29f;
    public float endPosition = -29f;

    private void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        transform.position += Vector3.down * speedMove * Time.deltaTime;
        if (transform.position.y <= endPosition)
            transform.position = Vector3.up * startPosition;
    }
}
