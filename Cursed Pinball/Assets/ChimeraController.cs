using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeraController : MonoBehaviour
{
    public GameObject LFlipper;
    public GameObject RFlipper;
    public GameObject Ball;
    public Transform RespawnArea;

    private Rigidbody2D ballRB;

    [Header("Settings To Fiddle With")]
    public float launchSpeed = 1;
    public bool LFlipperContact = false;
    public bool RFlipperContact = false;
    public float flipperVelocity = 1;

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
        bool superResetPressed = Input.GetKeyDown(KeyCode.R);

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

    public void FlipperLaunchBall()
    {
        //ballRB.velocity += new Vector2(0, launchSpeed/2);
    }
}
