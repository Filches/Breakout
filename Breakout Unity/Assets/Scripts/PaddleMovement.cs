using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerController
{
    player1,
    player2
}

public class PaddleMovement : MonoBehaviour
{
    public PlayerController playerSetting;
    public string axisName;
    public float paddleSpeed = 1f;

    private Vector3 playerPos = new Vector3(-2, 0, -2);
    private Vector3 player2Pos = new Vector3(-8, -2, -8);

    private void Start()
    {

        if (playerSetting == PlayerController.player1)
        {
            axisName = "Red Ship";
        }
        if (playerSetting == PlayerController.player2)
        {
            axisName = "Blu Ship";
        }
    }

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis(axisName) * paddleSpeed);
        if(playerSetting == PlayerController.player1)
        {
            playerPos = new Vector3(Mathf.Clamp(xPos, -12f, 12f), 0f, -2);
        }
        if(playerSetting == PlayerController.player2)
        {
            playerPos = new Vector3(Mathf.Clamp(xPos, -16f, 8f), 60f, 4);
        }
        transform.position = playerPos;

    }

}
