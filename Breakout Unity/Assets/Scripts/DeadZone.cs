using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == "RedDeadZone")
        {
            GM.instance.LoseLifeRed();
        }

        if (gameObject.tag == "BluDeadZone")
        {
            GM.instance.LoseLifeBlu();
        }
            
    }

}
