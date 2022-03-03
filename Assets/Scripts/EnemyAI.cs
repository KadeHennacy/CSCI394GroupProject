using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 0.2f;
    private Rigidbody2D rb;
    public Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(angle > 90)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 1);
        }
        else if (angle < 90)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }
        rb.rotation = Mathf.Clamp(angle, -90, 90);
        //rb.rotation = (angle);
        direction.Normalize();
        movement = direction;
    }
    void FixedUpdate(){
        move(movement);
    }
    void move(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
