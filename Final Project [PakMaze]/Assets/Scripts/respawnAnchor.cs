using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnAnchor : MonoBehaviour
{
    public float maxRange;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.parent.position, transform.position);
        if (distance > maxRange)
        {
            Destroy(gameObject);

            this.transform.parent.GetComponent<respawnEnemy>().isAlive = false;

        }
    }
}
