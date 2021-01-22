using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform movementPoint;

    public LayerMask collisonsMask;

    public GameObject Camera;
    public GlobalController GlobalData;

    private bool hasMoved = false;
    private int encounterIterator = 0;
    public int encounterChance = 25;
    public int encounterQuantity = 10;

    private System.Random rng;

    void Start()
    {
        GlobalData = GameObject.Find("GlobalData").GetComponent<GlobalController>();
        transform.position = GlobalData.getPlayerPosition();
        Camera.transform.position = GlobalData.getCameraPosition();
        rng = new System.Random();
        movementPoint.parent = null;

        GlobalData.setInFightState(false);
    }

    void Update()
    {
        if (hasMoved) {
            hasMoved = false;
            if (encounterIterator >= encounterQuantity) {
                encounterIterator = 0;
                if (rng.Next(101) < encounterChance) {
                    savePositionToGlobal();
                    Application.LoadLevel(1);
                }
            }
            else encounterIterator++; 
        }

        transform.position = Vector3.MoveTowards(transform.position, movementPoint.position, movementSpeed * Time.deltaTime);
        Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, new Vector3(movementPoint.position.x, movementPoint.position.y, -10), movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movementPoint.position) <= 0.5f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movementPoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, collisonsMask))
                {
                    movementPoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    hasMoved = true;
                }
            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movementPoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, collisonsMask))
                {
                    movementPoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    hasMoved = true;
                }
            }
        }
    }

    public void savePositionToGlobal() {
        GlobalData.SavePosition(transform.position);
    }
}
