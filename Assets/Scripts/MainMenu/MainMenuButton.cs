using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public void startNewGame() {
        Debug.Log("Starting New Game");
    }

    public void continueGame() {
        Debug.Log("Continue existing game");
    }

    public void lanuchExampleFight() {
        Application.LoadLevel(1);
    }

    public void quit() {
        Application.Quit();
    }
}
