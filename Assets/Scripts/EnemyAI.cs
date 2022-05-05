using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 0.18f;
    private Rigidbody2D rb;
    public Vector2 movement;
    public GameObject healthBar;
    private Health healthScript;
    private BoxCollider2D boxCollider;
    public GameObject sprite;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        healthScript = GetComponent<Health>();
    }
    private void OnCollisionEnter2D(Collision2D col){
        //look at col to see what hit enemy
        if(col.gameObject.name == "projectile(Clone)"){
            Debug.Log("projectile hits enemy");
            healthScript.TakeDamage(20);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = (angle);
        direction.Normalize();
        movement = direction;
    }
    void FixedUpdate(){
        rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
        //ensure the spirte and healthbar don't rotate
        healthBar.transform.rotation = Quaternion.Euler(0, 0, 0);
        sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        healthBar.transform.position = transform.position + new Vector3(0, -0.25f, 0);
        sprite.transform.localPosition = new Vector3(0, 0, 0);
    }
    void move(Vector2 direction){
        
        // sprite.transform.rotation = (-angle);
    }
}
