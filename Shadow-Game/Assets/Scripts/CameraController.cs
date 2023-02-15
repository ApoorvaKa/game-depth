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
    public float shakeDur = 1f;
    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    public float rotationMultiplier = 7.5f;
    public static CameraController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currPosition = transform.position;
        size = gameObject.GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    
    public void Shake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
        shakeFadeTime = power / length;
        shakeRotation = power * rotationMultiplier;
    }

    void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * shakeRotation * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
        }
        if (shakeTimeRemaining <= 0)
        {
            if(following){
                transform.position = player.transform.position + new Vector3(0, 1, -5);
                gameObject.GetComponent<Camera>().orthographicSize = zoom;
            } else{
                transform.position = currPosition;
                gameObject.GetComponent<Camera>().orthographicSize = size;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }   
    }

    
}
