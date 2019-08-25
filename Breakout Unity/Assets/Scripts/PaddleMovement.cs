using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float paddleSpeed = 1f;

    private Vector3 playerPos = new Vector3(-2, 0, -2);

    private void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -14f, 10f), 0f, -2);
        transform.position = playerPos;

    }
}
