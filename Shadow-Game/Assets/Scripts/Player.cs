using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _direction;

    void Start()
    {
        // Repeat the Move() function every 0.04 seconds 
        //      -> increase time to make player slower
        InvokeRepeating("Move", 0.04f, 0.04f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
        }   
        else if (Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
        }
    }

    public void Move(){
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x + _direction.x), 
            Mathf.Round(this.transform.position.y + _direction.y), 
            0.0f
        );
    }
}
