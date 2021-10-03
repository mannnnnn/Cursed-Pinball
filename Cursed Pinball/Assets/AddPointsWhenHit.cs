using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointsWhenHit : MonoBehaviour
{
    public int pointAmt;
    private Rigidbody2D rb;
    private ChimeraController chimera;
    void Start()
    {
        chimera = ChimeraController.GetInstance();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            chimera.AddPoints(ChimeraController.PointType.BUMPER, pointAmt);
        }
    }
}
