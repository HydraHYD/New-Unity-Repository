using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldenemyMovements : MonoBehaviour
{
    float rotateThis;
    float targetRotation;
    bool rotating = false;
    bool moving = false;
    Vector3 translation;
    float nextChange;
    float travelDistance;
    float speedMult = 0.01f;
    

    // Start is called before the first frame update
    void Start()
    {
        rotateThis = 0;
        targetRotation = Random.Range(-1, 2) * 90;
        travelDistance = Random.Range(1, 10);
        nextChange = Random.Range(1, 10);
    }

    void Wander()
    {
        if (travelDistance > 0)
        {
            moving = true;

            if (rotating == false)
            {
                translation.x = 1 * speedMult;
                this.transform.Translate(translation);
                travelDistance -= 1 * speedMult;
            }
            
        }
        else if (travelDistance == 0)
        {
            translation.x = 0;
            moving = false;
        }
        
    }

    void Rotate()
    {
        
        if (rotateThis < targetRotation)
        {
            rotateThis += 1;
        }
        else if (rotateThis > targetRotation)
        {
            rotateThis -= 1;
        }
        if (rotateThis != targetRotation)
        {
            rotating = true;
        }
        else if (rotateThis == targetRotation)
        {
            rotating = false;
        }
        transform.rotation = Quaternion.AngleAxis(rotateThis, Vector3.up);        

    }

    void OnCollisionEnter()
    { 
    
    
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == false && rotating == false)
        {
            if (nextChange > 0)
            {
                nextChange -= 1;
            }
            else if (nextChange == 0)
            {
                targetRotation = Random.Range(-1, 2) * 90;
                travelDistance = Random.Range(1, 10);
                nextChange = Random.Range(1, 10);
            }

        }
        Rotate();
        Wander();
            

    }
}
