using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //get the players box collider
    private BoxCollider2D boxCollider;
    //vector to track change in movement
    private Vector3 moveDelta;
    //to detect collisions with blocking objects
    private RaycastHit2D hit;
    //to take damage and heal
    public GameObject healthBar;
    private Health healthScript;
    public int moveSpeed = 1;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        healthScript = GetComponent<Health>();
    }
    private void OnCollisionEnter2D(Collision2D col){
        Debug.Log(col.gameObject.name);
        //look at col to see what hit player
        if(col.gameObject.name.Contains("enemy")){
            Debug.Log("badChungus hits player");
            healthScript.TakeDamage(20);
        }
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
        moveDelta = new Vector3(x * moveSpeed, y * moveSpeed, 0);
        
        //swap sprite direction depending on which direction player is moving
        if(moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            healthBar.transform.localScale = new Vector3(1,1,1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //healthbar shouldn't move
            healthBar.transform.localScale = new Vector3(-1,1,1);
        }
        //Check if player can move in y direction by casting a box there and detecting collisions with the Actor and Blocking layers
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        //if player doesn't hit a blocking object in y direction, move in y direction. Use time.deltatime so movement is independent from framerate.
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        //do the same thing for x axis
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
