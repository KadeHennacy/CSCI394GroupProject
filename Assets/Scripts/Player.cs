using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //get the players box collider
    private BoxCollider2D boxCollider;
    //vector to track change in movement
    private Vector3 moveDelta;

    private void start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    //we need fixed update because we're using physics with manual collision detection, so it needs to follow the physics
    //theres a rare chance it could skip some inputs, but we don't have a choice if we're using manual collision detection
    private void FixedUpdate()
    {
        //reset moveDelata to start fresh each frame
        moveDelta = Vector3.zero;
        //now we look for keyboard inputs to add to movedelta
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //add any inputs to movedelta
        moveDelta = new Vector3(x, y, 0);
        
        //swap sprite direction depending on which direction player is moving
        if(moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //now we apply the change in movement to the player. Use time.deltatie so movement is independent from framerate.
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
