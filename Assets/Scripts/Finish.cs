using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This loads the next scene when player reaches the end of a level
// based on https://www.youtube.com/watch?v=dO5BzWYqEdY
public class Finish : MonoBehaviour
{
    // this won't work until sound effects are added
    // must add audiosource component to finish object before this will work, otherwise it needs to be serialized
    private AudioSource finishSound;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }
    //player must have ridgidbody2d
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name.Contains("Player")){
            // finishSound.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel(){
        Debug.Log("complete Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
