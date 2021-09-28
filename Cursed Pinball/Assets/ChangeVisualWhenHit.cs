using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ChangeVisualWhenHit : MonoBehaviour
{
    private Color origColor;
    public Color hitColor;
    public float lerpTime = 1;

    private Vector3 origScale = Vector3.one;
    public Vector3 hitScale = Vector3.one;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    float hitTimer = 1f;
   //this isn't quite working yet, but almost

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        origScale = transform.localScale;
        origColor = sprite.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitTimer = lerpTime*2;
        }
    }

    void Update()
    {
        if (hitTimer > 0)
        {
            hitTimer -= Time.time;
            sprite.color = Color.Lerp(origColor, hitColor, Mathf.PingPong(Time.time, lerpTime));
        }
    }
}
