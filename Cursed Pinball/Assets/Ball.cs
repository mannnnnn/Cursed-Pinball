using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    ChimeraController chimera;
    private AudioSource audio;
    private Rigidbody2D rb;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        chimera = ChimeraController.GetInstance();
    }

    private void Update()
    {
        float yPos = transform.position.y + 2;

        audio.volume = 1 * (rb.velocity.magnitude/0.6f) * (4-yPos)/4;    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftFlipper")
        {
            chimera.LFlipperContact = true;
        }
        if (collision.gameObject.tag == "RightFlipper")
        {
            chimera.RFlipperContact = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftFlipper")
        {
            chimera.LFlipperContact = true;
        }
        if (collision.gameObject.tag == "RightFlipper")
        {
            chimera.RFlipperContact = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftFlipper")
        {
            chimera.LFlipperContact = false;
        }
        if (collision.gameObject.tag == "RightFlipper")
        {
            chimera.RFlipperContact = false;
        }
    }
}
