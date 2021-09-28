using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public KeyCode key;
    public float flipperVelocity = 10;
    public float angleLowerBound = 0;
    public float angleUpperBound = 0;
    public bool reverseRotation = false;
    private Rigidbody2D rb;
    private AudioSource audio;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool keyPressed = Input.GetKey(key);
        bool keyHit = Input.GetKeyDown(key);
        bool keyRelease = Input.GetKeyUp(key);

        if (keyHit)
        {
            audio.Play();
        }

        if (keyPressed)
        {
            FlipperHit();
        }

        if (keyRelease)
        {
            FlipperRelease();
        }


        if (transform.rotation.z >= angleUpperBound)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, angleUpperBound, transform.rotation.w);
           if(rb.angularVelocity > 0)
            {
                rb.angularVelocity = 0;
            }
           
            
        }
         else if (transform.rotation.z <= angleLowerBound)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, angleLowerBound, transform.rotation.w);
            if (rb.angularVelocity < 0)
            {
                rb.angularVelocity = 0;
            }
        }

       

        
    }

    public void FlipperHit()
    {
        rb.angularVelocity = flipperVelocity * (reverseRotation ? -1 : 1);
    }

    public void FlipperRelease()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = -flipperVelocity * (reverseRotation ? -1 : 1);
    }
}
