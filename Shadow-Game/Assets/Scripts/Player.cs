using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform segmentPrefab;
    public Transform cornerPrefab;
    private Vector2 _direction;
    public Transform spawnArea;
    public string dir = "w";

    public float movespeed = 10;
    public List<Transform> _segments;
    public List<Transform> corners;

    public Transform currSeg;

    

    void Start()
    {
        _segments = new List<Transform>();
        corners = new List<Transform>();
        currSeg = SpawnSeg();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 Move = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)){
            Move = new Vector3(0, 1f, 0);
            if(dir == "w" || dir == "e"){
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                SpawnCorners(dir, "s");
                dir = "s";
            } 
        }   
        else if (Input.GetKey(KeyCode.S)){
            Move = new Vector3(0, -1f, 0);
            if(dir == "w" || dir == "e"){
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                gameObject.GetComponent<SpriteRenderer>().flipY = true;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                SpawnCorners(dir, "n");
                dir = "n";
            }
            
        }
        else if (Input.GetKey(KeyCode.A)){
            Move = new Vector3(-1f, 0, 0);
            if(dir == "n" || dir == "s"){
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
                SpawnCorners(dir, "e");
                dir = "e";
            }
        }
        else if (Input.GetKey(KeyCode.D)){
            Move = new Vector3(1f, 0, 0);
            if(dir == "n" || dir == "s"){
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
                SpawnCorners(dir, "w");
                dir = "w";
            }   
        }
    
        transform.position += Move * Time.deltaTime*(movespeed);
        currSeg.localScale = new Vector3(Move.x*.00025f + currSeg.localScale.x + Move.x * (Time.deltaTime*movespeed)/2,currSeg.localScale.y,currSeg.localScale.z);

    }

    private Transform SpawnSeg(){
        float width = segmentPrefab.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
        Vector3 spawnpos = new Vector3(spawnArea.position.x-width,spawnArea.position.y,spawnArea.position.z);
        Transform newSegment = Instantiate(segmentPrefab,spawnpos,transform.rotation);
        
        _segments.Add(newSegment);
        return newSegment;
    }

    private Transform SpawnCorners(string olddir, string newdir){
        //Vector3 spawnpos = new Vector3(spawnArea.position.x-width,spawnArea.position.y,spawnArea.position.z);
        Transform newCorner = Instantiate(cornerPrefab,transform.position,transform.rotation);
        newCorner.GetComponent<Corner>().Setup(currSeg.gameObject,olddir,newdir);
        corners.Add(newCorner);
        return newCorner;
    }

    // Handle collisions
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Obstacle"){
            ResetPlayer();
        }
        if (other.tag == "powerup"){
            DeleteTail();
            Destroy(other.gameObject);
        }
    }

    // get rid of player tail
    private void DeleteTail(){
        for (int i = 1; i < _segments.Count; i++){
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(transform); // add the player to the segments list
    }

    // reset the player to the starting position
    private void ResetPlayer(){
        DeleteTail();
        transform.position = Vector3.zero;
    }

    /*
     old snake code
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0f,0f,90f);
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }   
        else if (Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0f,0f,90f);
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
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
    */


}
