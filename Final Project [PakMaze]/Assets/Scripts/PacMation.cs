using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMation : MonoBehaviour
{

    public float currentRotation = 0f;
    public float rotationLimitUp = 45f;
    public float rotationLimitDown = 0f;
    public bool reverse = false;
    GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.transform.parent.gameObject;
    }

    // Update is called once per frame

    void Update()
    {
        if (currentRotation > rotationLimitUp)
        {
            reverse = true;
        }
        else if (currentRotation < rotationLimitDown)
        {
            reverse = false;
        }
        if (reverse == false)
        {
            currentRotation += 1f;
        }

        else if (reverse == true)
        {
            currentRotation -= 1f;
        }
        this.transform.localRotation = Quaternion.AngleAxis(currentRotation, Vector3.right);
        /*var rotate1 = transform.rotation;

        this.transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, 0, 45, 0), 1f);*/

    }
}
