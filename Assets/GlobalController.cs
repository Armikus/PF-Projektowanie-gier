using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;


    private List<Enemy> enemies;
    private int hp;
    private Vector3 position;
    private Vector3 cameraPosition;
    private bool inFight;

    private bool battleContinuation;

    private bool bossFight;

    void Start()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            resetGlobalData();
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    public void setBattleContinuation(bool state) { GlobalController.Instance.battleContinuation = state; }
    public bool getBattleContinuation() { return GlobalController.Instance.battleContinuation; }

    public void SaveHp(int hp) {
        GlobalController.Instance.hp = hp;
    }

    public void setInFightState(bool state) { GlobalController.Instance.inFight = state; }
    public bool getFightState(){ return GlobalController.Instance.inFight; }

    public void SavePosition(Vector3 position) {
        GlobalController.Instance.position = position;
        GlobalController.Instance.cameraPosition = position - new Vector3( 5f, 5f, 0f);
    }

    public Vector3 getPlayerPosition() { return GlobalController.Instance.position; }
    public Vector3 getCameraPosition() { return GlobalController.Instance.cameraPosition; }
    public int getPlayerHealth() { return GlobalController.Instance.hp; }

    public List<Enemy> getEnemies() { return GlobalController.Instance.enemies; }
    public void saveEnemies(List<Enemy> enemies) { GlobalController.Instance.enemies = enemies; }

    public bool isBossFight() { return GlobalController.Instance.bossFight; }
    public void setBossFightStatus(bool value) { GlobalController.Instance.bossFight = value; }

    public void resetGlobalData() {
        hp = 30;
        position = new Vector3(-2.5f, 1.1f, 0f);
        cameraPosition = new Vector3(-2.5f, 1.1f, 0f);
        inFight = false;
        enemies = null;
        battleContinuation = false;
        bossFight = false;
    }

}
