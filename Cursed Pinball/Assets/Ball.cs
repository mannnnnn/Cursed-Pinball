using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    ChimeraController chimera;
    void Start()
    {
        chimera = ChimeraController.GetInstance();
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
