using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public GlobalController GlobalData;

    void Start() {
        GlobalData = GameObject.Find("GlobalData").GetComponent<GlobalController>();
    }

    public void startNewGame() {
        GlobalData.resetGlobalData();
        Application.LoadLevel(2);
        Debug.Log("Starting New Game");
    }

    public void continueGame() {
        if (GlobalData.getBattleContinuation()) {
            Application.LoadLevel(1);
        }
        else Application.LoadLevel(2);
        Debug.Log("Continue existing game");
    }

    public void lanuchExampleFight() {
        Application.LoadLevel(1);
    }

    public void quit() {
        Application.Quit();
    }
}
