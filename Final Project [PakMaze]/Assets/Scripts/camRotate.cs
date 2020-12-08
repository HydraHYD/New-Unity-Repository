using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class camRotate : MonoBehaviour
{

    Vector2 mouseLook;
    Vector2 smoothV;
    Vector2 limitRotate;
    public float sensitivity = 2f;
    public float smoothing = 2f;

    GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var change = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        change = Vector2.Scale(change, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, change.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, change.y, 1f / smoothing);
        mouseLook += smoothV;


        if (mouseLook.y > 90)
        {
            mouseLook.y = 90;
        }

        else if (mouseLook.y < -90)
        {
            mouseLook.y = -90;
        }
        
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        parentObject.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, parentObject.transform.up);

    }
}
