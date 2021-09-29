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
        bool jiggleBoard = Input.GetKeyDown(KeyCode.J);
        if (jiggleBoard)
        {
            JiggleMachine();
        }
    }

    public void ResetBall()
    {
        Ball.transform.position = RespawnArea.position;
    }

    public void LaunchBall()
    {
        ballRB.velocity = new Vector2(launchSpeed, 0);
    }

    public void JiggleMachine()
    {
        int randDir = Random.Range(-1, 1);
        if(randDir >= 0)
        {
            ballRB.velocity = new Vector2(ballRB.velocity.x + 0.2f, ballRB.velocity.y);
        } else
        {
            ballRB.velocity = new Vector2(ballRB.velocity.x -0.2f, ballRB.velocity.y);
        }
        Camera.main.GetComponent<Animator>().SetTrigger("jiggle");


    }
}
