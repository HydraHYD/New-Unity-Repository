using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnEnemy : MonoBehaviour
{
    public bool isAlive;
    public GameObject spawnPrefab;
    public float respawnTimer;
    float timeTillRespawn;


    // Start is called before the first frame update
    void Start()
    {
        timeTillRespawn = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == false)
        {
            isAlive = true;
            timeTillRespawn = respawnTimer;
        }
        if (timeTillRespawn > 0)
        {
            timeTillRespawn -= 1;
        }
        else if (timeTillRespawn == 0)
        {
            timeTillRespawn = -1;
            var newGhost = Instantiate(spawnPrefab, this.transform);
            newGhost.transform.parent = gameObject.transform;
        }
    }
}
