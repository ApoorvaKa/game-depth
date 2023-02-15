using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            CameraController.instance.Shake(.3f,.2f);
        }
    }

}
