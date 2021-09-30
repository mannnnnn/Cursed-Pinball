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

   public float t = 0;

    //this isn't quite working yet, but almost
    public bool changeUp = false;
    bool changeDown = false;
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
            changeUp = true;
            t = 0;
        }
    }

    private void Update()
    {
        if(changeUp && t < lerpTime*2)
        {
            t += Time.deltaTime;
            sprite.color = Color.Lerp(origColor, hitColor, Mathf.PingPong(t, lerpTime));
            transform.localScale = new Vector2(Mathf.Lerp(origScale.x, hitScale.x, Mathf.PingPong(t, lerpTime)), Mathf.Lerp(origScale.y, hitScale.y, Mathf.PingPong(t, lerpTime)));
        } else { 
            changeUp = false;
        }
       
    }
}
