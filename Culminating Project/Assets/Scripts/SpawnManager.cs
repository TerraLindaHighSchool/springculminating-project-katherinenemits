using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject conePrefab;
    private float startDelay = 2;
    private float repeatRate = 2;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private Vector3 spawnPos2 = new Vector3(35, 0, 0);
    private Vector3 spawnPos3 = new Vector3(40, 0, 0);
    private PlayerController playerControllerScript;
    private float spawnInterval = 1f;
    // Start is called before the first frame update

    void Start()
    {

        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

    }
    //spawns the obstacles
    void SpawnObstacle()
    {

        //makes sure if game is over to stop spawning obstacles
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(25, 0, Random.Range(-3, 3));
            Vector3 spawnPos2 = new Vector3(35, 0, Random.Range(-3, 3));
            Vector3 spawnPos3 = new Vector3(40, 0, Random.Range(-3, 3));
              Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
              Instantiate(obstaclePrefab, spawnPos3, obstaclePrefab.transform.rotation);
              Instantiate(conePrefab, spawnPos2, conePrefab.transform.rotation);

        }
    }
}

