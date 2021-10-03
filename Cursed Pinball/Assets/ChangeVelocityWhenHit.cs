using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVelocityWhenHit : MonoBehaviour
{
    public bool reflectBall = false;
    public bool speedUpBall = false;
    public bool pushSelf = false;

    public float ballVelScale;
    public float selfVelScale;

    private Rigidbody2D rb;
    private ChimeraController chimera;

    public float minMagnitude = 5;
    void Start()
    {
        chimera = ChimeraController.GetInstance();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == "Ball" && reflectBall)
        {
            Rigidbody2D oRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Ball ball = collision.gameObject.GetComponent<Ball>();
            oRB.velocity = ball.lastConsistentVelocity * -1 * ballVelScale;

            if(oRB.velocity.magnitude == 0)
            {
                oRB.velocity = new Vector2(1, 1);
            } else

           while(oRB.velocity.magnitude < minMagnitude && oRB.velocity.magnitude > -minMagnitude)
            {
                oRB.velocity = oRB.velocity * 1.1f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && speedUpBall)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            Rigidbody2D oRB = collision.gameObject.GetComponent<Rigidbody2D>();
            oRB.velocity = ball.lastConsistentVelocity * (1+ballVelScale);
            while (oRB.velocity.magnitude < minMagnitude)
            {
                oRB.velocity = oRB.velocity * 1.1f;
            }
        }
    }
}
