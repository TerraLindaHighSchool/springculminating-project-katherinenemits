using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        //gets the player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // moves the object and background to the left
    void Update()
    {
        //gets the status of game over; if true then it stops the game
        if(playerControllerScript.gameOver == false)
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        //destrows obstacles that go out of the game view
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
