using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//based on this https://www.youtube.com/watch?v=aoZqeG7rqV0
public class Health : MonoBehaviour
{
    public Image healthBar;
    public float maxHP= 100;
    private float healthAmount;
    
    void Start(){
        healthAmount = maxHP;
    }
    void FixedUpdate()
    {
        if(healthAmount <= 0){
            if(gameObject.name.Contains("Player")){
                Destroy(gameObject);
                Debug.Log("Game Over");
                SceneManager.LoadScene("GameOver");
         }
        //  check whether the script is on the player or an enemy. If it's on player, load a gameover level
        //e.g. Application.LoadLevel(Application.loadedLevel);
        //must be parent since bar is on canvas
        if(gameObject.name.Contains("enemy")){
            //replace this with animation if we choose
            Debug.Log("enemy dead");
            Destroy(gameObject);
        }
     }
     //for testing
     if(Input.GetKeyDown(KeyCode.E)){
         TakeDamage(5);
     }
     if(Input.GetKeyDown(KeyCode.Q)){
         Healing(5);
     }
    }
    public void TakeDamage(float Damage){
        // projectile.cs should call this on collision
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / maxHP;
    }
    public void Healing(float healPoints){
        // I think we will just do health regen so I may just use a timer rather than this method
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHP);
        healthBar.fillAmount = healthAmount / maxHP;
    }
}
