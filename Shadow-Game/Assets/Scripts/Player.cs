using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform segmentPrefab;

    private Vector2 _direction;
    private List<Transform> _segments;

    void Start()
    {
        // Repeat the Move() function every 0.04 seconds -> boost time to make slower
        InvokeRepeating("Move", 0.04f, 0.04f);

        _segments = new List<Transform>();
        _segments.Add(transform);
        InvokeRepeating("Grow", 2, 2);
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
        // move the segments in reverse order each segment is following the one in front of it
        for (int i = _segments.Count - 1; i > 0; i--){
            _segments[i].position = _segments[i - 1].position;
        }
        // move the head in the direction of the input
        transform.position = new Vector3(
            Mathf.Round(transform.position.x + _direction.x), 
            Mathf.Round(transform.position.y + _direction.y), 
            0.0f
        );
    }

    // create a new segment, place it on "tail end" of the shadow, and add it to the list
    private void Grow(){
        Transform newSegment = Instantiate(segmentPrefab);
        newSegment.position = _segments[_segments.Count - 1].position;
        _segments.Add(newSegment);
    }
}
