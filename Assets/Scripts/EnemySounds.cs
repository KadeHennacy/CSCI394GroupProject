using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    private AudioSource enemySound;

    private void Start(){
        enemySound = GetComponent<AudioSource>();
    }

    private void OnBecameVisible(){
        enemySound.Play();
    }
}
