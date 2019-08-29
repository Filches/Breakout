using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{

    public GameObject brickParticles;

    void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag == "Blocks")
        {
            if (other.gameObject.tag == "RedBall")
            {
                Instantiate(brickParticles, transform.position, Quaternion.identity);
                GM.instance.DestroyRedBrick();
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Blocks2")
        {
            if (other.gameObject.tag == "BluBall")
            {
                Instantiate(brickParticles, transform.position, Quaternion.identity);
                GM.instance.DestroyBluBrick();
                Destroy(gameObject);
            }
        }

    }

}
