using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryMotion : MonoBehaviour
{

    public float currentRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        currentRotation += 1f;
        this.transform.rotation = Quaternion.AngleAxis(currentRotation, Vector3.up);

    }
}
