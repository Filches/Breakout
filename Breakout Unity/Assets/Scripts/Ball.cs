using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballInitialVelocity = 600f;

    public AudioClip Blox;

    public AudioClip[] bep;
    private AudioClip bip;
    private AudioSource bop;

    private Rigidbody rb;
    private bool ballInPlay;

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        bop = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int index = Random.Range(0, bep.Length);
            bip = bep[index];
            bop.PlayOneShot(bip);
        }

        if (collision.gameObject.tag == "Blocks")
        {
            bop.PlayOneShot(Blox);
        }
    }



}
