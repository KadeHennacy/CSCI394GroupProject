using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collision2D collision)
    {
        if (collision.gameObject.name == "Square")
        {
            SceneManager.LoadScene("scene2");
        }
    }
}
