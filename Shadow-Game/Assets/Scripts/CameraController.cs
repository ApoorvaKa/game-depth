using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 currPosition;
    private float size;
    public bool following;
    public float zoom = 5f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currPosition = transform.position;
        size = gameObject.GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(following){
            transform.position = player.transform.position + new Vector3(0, 1, -5);
            gameObject.GetComponent<Camera>().orthographicSize = zoom;
        } else{
            transform.position = currPosition;
            gameObject.GetComponent<Camera>().orthographicSize = size;
        }
    }
}
