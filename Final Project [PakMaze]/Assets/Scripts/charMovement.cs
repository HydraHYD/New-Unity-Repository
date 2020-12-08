using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody gravBody;
    public float movespeed = 0.1f;

    void Start()
    {

        //Destroy(gameObject,1);
        gravBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void basicmove()
    {

        if (Input.GetKey(KeyCode.Space) && this.transform.position.y < 3)
        {
            gravBody.AddForce(Vector3.up * 10);
            
        }
        float verticalmove = Input.GetAxis("Vertical") * movespeed;
        float horizontalmove = Input.GetAxis("Horizontal") * movespeed;
        

        transform.Translate(horizontalmove, 0, verticalmove);


    }



    // Update is called once per frame
    void Update()
    { }

    void FixedUpdate()
    {
        basicmove();
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
