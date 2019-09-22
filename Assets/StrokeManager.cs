using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindPlayerBall();
        StrokeCount = 0;
    }

    public float StrokeAngle { get; protected set; }

    public float StrokeForce { get; protected set; }
    public float StrokeForcePerc { get { return StrokeForce / MaxStrokeForce; } }

    public int StrokeCount { get; protected set; }

    float strokeForceFillSpeed = 5f;
    int fillDir = 1;

    float MaxStrokeForce = 10f;

    public enum StrokeModeEnum {
        AIMING,
        FILLING,
        DO_WHACK,
        BALL_IS_ROLLING
    };

    public StrokeModeEnum StrokeMode { get; protected set; }

    Rigidbody playerBallRB;

    private void FindPlayerBall()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player"); // slow and dumb and could do badness

        if(go == null)
        {
            Debug.LogError("Couldn't find the ball.");
        }

        playerBallRB = go.GetComponent<Rigidbody>();

        if(playerBallRB == null)
        {
            Debug.LogError("Ball has no rigidbody?!?!?");
        }
    }

    // Update is called once per visual frame -- use this for inputs
    private void Update()
    {
        if (StrokeMode == StrokeModeEnum.AIMING)
        {
            StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;

            if (Input.GetButtonUp("Fire"))
            {
                StrokeMode = StrokeModeEnum.FILLING;
                return;
            }
        }

        if(StrokeMode == StrokeModeEnum.FILLING)
        {
            StrokeForce += (strokeForceFillSpeed * fillDir) * Time.deltaTime;
            if(StrokeForce > MaxStrokeForce)
            {
                StrokeForce = MaxStrokeForce;
                fillDir = -1;
            }
            else if (StrokeForce < 0)
            {
                StrokeForce = 0;
                fillDir = 1;
            }

            if (Input.GetButtonUp("Fire"))
            {
                StrokeMode = StrokeModeEnum.DO_WHACK;
            }

        }


    }

    void CheckRollingStatus()
    {
        // Is the ball still rolling?
        if(playerBallRB.IsSleeping())
        {
            StrokeMode = StrokeModeEnum.AIMING;
        }
    }

    // FixedUpdate runs on every tick of the physics engine, use this for manipulation
    void FixedUpdate()
    {
        if (playerBallRB == null)
        {
            // Might not be an error -- maybe the ball fell out of bounds, got deleted,
            // and hasn't respawned yet.
            return;
        }

        if(StrokeMode == StrokeModeEnum.BALL_IS_ROLLING)
        {
            CheckRollingStatus();
            return;
        }

        if (StrokeMode != StrokeModeEnum.DO_WHACK)
        {
            return;
        }

        // Whackadaball

        Debug.Log("Whacking it!");

        Vector3 forceVec = new Vector3(0, 0, StrokeForce);

        playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse);

        StrokeForce = 0;
        fillDir = 1;
        StrokeCount++;

        StrokeMode = StrokeModeEnum.BALL_IS_ROLLING;
    }
}
