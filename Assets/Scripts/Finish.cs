using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This loads the next scene when player reaches the end of a level
// based on https://www.youtube.com/watch?v=dO5BzWYqEdY
public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name.Contains("Player")){
            CompleteLevel();
        }
    }

    private void CompleteLevel(){
        Debug.Log("complete Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
