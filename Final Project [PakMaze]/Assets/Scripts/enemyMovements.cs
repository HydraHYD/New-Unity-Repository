using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovements : MonoBehaviour
{
    /*enemy movements:

    standard movements:

    rotate one of 4 directions
    after rotating, move a random distance forward
    if it's not moving or rotating, start a new countdown
    when the countdown is complete, restart cycle*/
    
    //Initial Variables
    Vector3 enemyProperties;

    //Rotation Variables
    public float rotationSpeed = 1f;
    float currentRotation = 0;
    float newRotation = Random.Range(-2,2) * 90;

    //Movement Variables
    float targetDistance = Random.Range(5, 40);
    public float speedMult;
    Vector3 moveDistance;

    //Booleans
    bool rotate = true;
    bool moving = true;
    //bool currentCycle = true;

    //Timers
    float nextCycle;
    public float enemyPauseMax;
    public float enemyPauseMin;

    //player detect variables
    bool foundPlayer;
    public float detectionRange = 100f;
    public LayerMask player;
    RaycastHit interact;
    public float aggroTime;
    float aggro;

    //player chase variables


    // Start is called before the first frame update
    void Start()
    {
        moveDistance.z = 1f * speedMult;
        nextCycle = Random.Range(enemyPauseMin, enemyPauseMax);
    }

    void Rotate()
    {
        if (currentRotation < newRotation)
        {
            currentRotation += 1 * rotationSpeed;

        }

        if (currentRotation > newRotation)
        {
            currentRotation -= 1 * rotationSpeed;
        }

        if (currentRotation == newRotation)
        {
            rotate = false;
        }

        transform.rotation = Quaternion.AngleAxis(currentRotation, Vector3.up);
        

    }

    void Forward()
    {

        if (rotate == false && moving == true)
        {
            if (targetDistance > 0)
            {
                transform.Translate(moveDistance);
                targetDistance -= 1f * speedMult;
            }

            if (targetDistance < 0)
            {
                moving = false;
            }
        
        }
        
    }

    void ResetVariables()
    {
        if (rotate == false && moving == false)
        {
            newRotation = Random.Range(-2, 2) * 90;
            targetDistance = Random.Range(5, 40);
            rotate = true;
            moving = true;
            nextCycle = Random.Range(enemyPauseMin, enemyPauseMax);
            //currentCycle = true;

        }
    }

    void OnCollisionEnter(Collision Target)
    {
        
        if (Target.gameObject.tag == "map")
        {
            moving = false;
        }
        if (Target.gameObject.tag == "playable")
        {
            Destroy(Target.gameObject);
        }


    }

    void MoveCycle()
    {
        Rotate();
        Forward();
        ResetVariables();
    }

    // Player Detection
    void detectPlayers()
    {
        //foundPlayer = Physics.CheckSphere(transform.position, detectionRange, player);
        
        if (Physics.Raycast(transform.position, transform.forward, out interact, 50f))
        {
            if (interact.collider.tag == "playable")
                foundPlayer = true;
        }
    }

    void ChargePlayer()
    {
        transform.LookAt(interact.transform);
        rotate = false;
        Forward();
        if (moving == false)
        {
            targetDistance = Random.Range(5, 40);
            moving = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (foundPlayer == true)
        {
            aggro = aggroTime;
            foundPlayer = false;
        }

        if (aggro == 0)
        {
            if (nextCycle > 0)
            {
                nextCycle -= 1;
            }

            else
            {
                MoveCycle();
            }
            detectPlayers();
        }

        else if (aggro > 0)
        {
            ChargePlayer();
            aggro -= 1;
        }
    }
}
