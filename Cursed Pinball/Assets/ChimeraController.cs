using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChimeraController : MonoBehaviour
{
    public GameObject LFlipper;
    public GameObject RFlipper;
    public GameObject Ball;
    public Transform RespawnArea;

    private Rigidbody2D ballRB;

    [Header("Settings To Fiddle With")]
    public float launchSpeedX = 1;
    public float launchSpeedY = 1;
    public bool LFlipperContact = false;
    public bool RFlipperContact = false;
   
    private int points = 0;
    public Text pointsLabel;
    public int maxBallMagnitude = 50;


    public GameObject[] pointLights;
    public Dictionary<PointType, int> pointDictionary;


    public static ChimeraController GetInstance()
    {
        return FindObjectsOfType<ChimeraController>(true)[0];
    }

    // Start is called before the first frame update
    void Start()
    {
       
        ballRB = Ball.GetComponent<Rigidbody2D>();
        pointDictionary = new Dictionary<PointType, int>();
        pointDictionary.Add(PointType.BUMPER, 100);
        pointDictionary.Add(PointType.MONSTER_HIT, 100);
        pointDictionary.Add(PointType.MONSTER_KILLED, 100);
        pointDictionary.Add(PointType.LIMPING, 100);
        pointDictionary.Add(PointType.TRAP_SET, 100);
        pointDictionary.Add(PointType.TRAP_TRIGGERED, 100);
        pointDictionary.Add(PointType.NEXT_PHASE_TRIGGERED, 100);
        pointDictionary.Add(PointType.ITEM_COLLECTED, 100);
        pointDictionary.Add(PointType.ITEM_CRAFTED, 100);
        pointDictionary.Add(PointType.ITEM_USED, 100);
        pointDictionary.Add(PointType.WEAPON_FORGED, 100);
        pointDictionary.Add(PointType.MINION_HIT, 100);
        pointDictionary.Add(PointType.MINION_KILL, 100);
        pointDictionary.Add(PointType.BALL_BOOST, 100);
        pointDictionary.Add(PointType.EVENT_1, 100);
        pointDictionary.Add(PointType.EVENT_2, 100);
        pointDictionary.Add(PointType.EVENT_3, 100);
        pointDictionary.Add(PointType.EVENT_4, 100);
    }

    // Update is called once per frame
    void Update()
    {
        //i.ToString().PadLeft(4, '0')
        pointsLabel.text = points.ToString("00000000");

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
        ballRB.velocity = new Vector2(launchSpeedX, launchSpeedY);
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

    public enum PointType
    {
       DEFAULT,
       BUMPER, //bumpers choose how much to award
       MONSTER_HIT, //not kill
       MONSTER_KILLED, 
       LIMPING,
       TRAP_SET, //on different non-monster zones
       TRAP_TRIGGERED, //monsters trigger traps when moving areas
       NEXT_PHASE_TRIGGERED,
       ITEM_COLLECTED, //gathering or loot drop
       ITEM_CRAFTED, //crafting screen
       ITEM_USED, //potions, bombs, etc. left side
       WEAPON_FORGED, //between balls/monsters
       MINION_HIT, //have some small critters roaming around in back zones
       MINION_KILL, 
       BALL_BOOST, 
       EVENT_1,
       EVENT_2,
       EVENT_3,
       EVENT_4,
    }

    public void AddPoints(PointType pointType, int numOfPoints = -1)
    {
        if(numOfPoints > 0)
        {
            points += numOfPoints;
        } else if (pointDictionary.ContainsKey(pointType))
        {
            int pointsToAdd = 0;
            pointDictionary.TryGetValue(pointType, out pointsToAdd);
            points += pointsToAdd;
        }

        pointLights[(int)pointType - 1].GetComponent<PointItem>().PointTypeAcquired();
    }
}
