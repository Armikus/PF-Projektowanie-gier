﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyHover : MonoBehaviour
{
    public GameObject enemyDetails;
    public GameObject enemy;
    public GameObject targetCursor;
    public EnemyDatabase Enemies;


    private GameObject detailsBox;
    private GameObject Canvas;
    private int instanceId;
    private enemyControler EnemyControler;
    private PauseManager PauseMenu;

    private bool enterFlag = false;
    private bool selectedFlag = false;
    private bool isPaused = false;

    public void Awake()
    {
        Canvas = GameObject.Find("Background");
        PauseMenu = GameObject.Find("Pause").GetComponent<PauseManager>();
        EnemyControler = GameObject.Find("GameManager").GetComponent<enemyControler>();
    }

    public void OnMouseOver()
    {
        if (!isPaused)
        {
            if (!enterFlag)
            {
                instanceId = gameObject.GetComponent<enemyStatsHandler>().instanceId;
                if (!EnemyControler.checkIfDead(instanceId))
                {
                    enterFlag = true;

                    detailsBox = Instantiate(enemyDetails, new Vector2(transform.position.x * 115, transform.position.y + 50), Quaternion.identity);
                    gameObject.GetComponent<enemyStatsHandler>().fillDetailsTemplate(detailsBox);
                    detailsBox.transform.SetParent(Canvas.transform, false);
                }
            }
        }     
    }

    public void OnMouseExit()
    {
        if (!isPaused)
        {
            enterFlag = false;
            Destroy(detailsBox);
        }
    }

    public void OnMouseDown() {
        if (!isPaused)
        {
            instanceId = gameObject.GetComponent<enemyStatsHandler>().instanceId;
            if (!EnemyControler.checkIfDead(instanceId))
            {
                EnemyControler.selectedTarget = instanceId;
                selectTarget();
            }
        }
    }

    public void selectTarget()
    {
        if (!isPaused)
        {
            // EnemyControler.selectedTarget = instanceId;
            GameObject cursorArea = GameObject.Find("PointerArea");

            foreach (Transform child in cursorArea.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            GameObject cursor = Instantiate(targetCursor, new Vector2(transform.position.x * 115, transform.position.y + 200), Quaternion.identity);
            cursor.transform.SetParent(cursorArea.transform, false);
        }
    }

    void Update() {
            if (instanceId == EnemyControler.selectedTarget)
            {
                selectedFlag = true;
                selectTarget();
            }
            else if (instanceId == null)
            {
                Destroy(gameObject);
            }
            isPaused = PauseMenu.getState();
    }
}
