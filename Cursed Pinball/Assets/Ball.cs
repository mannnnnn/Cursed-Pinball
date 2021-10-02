using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    ChimeraController chimera;
    private AudioSource audio;
    private Rigidbody2D rb;

    public Vector2 lastConsistentVelocity = new Vector2(0,0);
    private List<Vector2> lastXVelocities;
    public int consistentVelocityNum = 5;//# of times a value needs to be logged
    public float logLeniancy = 1;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        chimera = ChimeraController.GetInstance();
        lastConsistentVelocity = rb.velocity;
        lastXVelocities = new List<Vector2>();
    }

    private void Update()
    {
        if(lastXVelocities.Count >= consistentVelocityNum)
        {
            lastXVelocities.RemoveAt(0);
        }
        lastXVelocities.Add(rb.velocity);
        bool allMatch = true;
        foreach(Vector2 vec in lastXVelocities)
        {
            if (Mathf.Abs(rb.velocity.x - vec.x)> logLeniancy || Mathf.Abs(rb.velocity.y - vec.y)> logLeniancy)
            {
                allMatch = false;
            }
        }
        if (allMatch)
        {
            lastConsistentVelocity = rb.velocity;
        }
       
        float yPos = transform.position.y + 2;
        audio.volume = 1 * (rb.velocity.magnitude/0.6f) * (4-yPos)/4;    


        while (rb.velocity.magnitude > chimera.maxBallMagnitude || rb.velocity.magnitude < -chimera.maxBallMagnitude)
        {
            rb.velocity = rb.velocity * 0.9f;
        }
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
