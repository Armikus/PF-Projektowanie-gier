using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    void start() { }

    void update() { }


    public void exitOnClick() {
        Debug.Log("Coming Back to main menu");
        Application.LoadLevel(0);
    }
}
