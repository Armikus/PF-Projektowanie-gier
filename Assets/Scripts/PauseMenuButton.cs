using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButton : MonoBehaviour
{

    private PauseManager pauseMenu;

    public GlobalController GlobalData;



    public void Awake() {
        GlobalData = GameObject.Find("GlobalData").GetComponent<GlobalController>();
        pauseMenu = GameObject.Find("Pause").GetComponent<PauseManager>();
    }

    public void buttonQuit() {
        if (GlobalData.getFightState())
        {
            GameObject.Find("GameManager").GetComponent<BattleSystem>().saveFightState();
        }
        else {
            GameObject.Find("Player").GetComponent<PlayerMovementController>().savePositionToGlobal();
        }
        Application.LoadLevel(0);
    }

    public void buttonContinue() {
        GameObject PauseMenu = GameObject.Find("Pause");
        for (int i = 0; i < PauseMenu.transform.childCount; i++)
        {
            PauseMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        pauseMenu.setState(false);
    }
}
