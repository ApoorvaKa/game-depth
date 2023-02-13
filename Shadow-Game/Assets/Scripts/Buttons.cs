using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame(){
        // Start the game by going to level 1
        print("Start Game Pressed");
        SceneManager.LoadScene("level_1");
    }

    public void QuitGame(){
        // Quit the game
        print("Quit Game Pressed");
        Application.Quit();
    }
}
