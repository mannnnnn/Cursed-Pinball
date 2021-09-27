using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeraController : MonoBehaviour
{
    public Animator LFlipper;
    public Animator RFlipper;
    public GameObject Ball;
    public Transform RespawnArea;

    private Rigidbody2D ballRB;

    [Header("Settings To Fiddle With")]
    public float launchSpeed = 1;

    public static ChimeraController GetInstance()
    {
        return FindObjectsOfType<ChimeraController>(true)[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        ballRB = Ball.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        bool leftPressed = Input.GetKey(KeyCode.LeftArrow);
        bool rightPressed = Input.GetKey(KeyCode.RightArrow);
        bool superResetPressed = Input.GetKeyDown(KeyCode.R);
        LFlipper.SetBool("FlipperHold", leftPressed);
        RFlipper.SetBool("FlipperHold", rightPressed);
        if (superResetPressed)
        {
            ResetBall();
            LaunchBall();
        }
    }

    public void ResetBall()
    {
        Ball.transform.position = RespawnArea.position;
    }

    public void LaunchBall()
    {
        ballRB.velocity += new Vector2(0, launchSpeed);
    }
}
