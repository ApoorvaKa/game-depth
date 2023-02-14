using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        int milliseconds = (int)(currentTime * 100) % 100;
        int seconds = (int)(currentTime) % 60;
        int minutes = (int)(currentTime / 60) % 60;
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        
    }
}
