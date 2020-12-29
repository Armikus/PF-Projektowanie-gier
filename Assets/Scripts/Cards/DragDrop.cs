using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private bool isPlayable = true;

    private GameObject dropZone;
    private Vector2 startPosition;
    private cardManager cardManager;
    private int cardId;

    private Animator animator;

    void Start() {
        GameObject gameManager = GameObject.Find("GameManager");
        cardManager = gameManager.GetComponent<cardManager>();
        animator = gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>();
        setHoveredCardId();
    }

    void setHoveredCardId() {
        Text[] textFields = gameObject.GetComponentsInChildren<Text>();
        for (int i = 0; i < textFields.Length; i++) {
            if (textFields[i].name == "Id") cardId = Int32.Parse(textFields[i].text);
        }
    }

    void Update()
    {
        if (isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (!cardManager.isCardPlayable(cardId))
        {
            isPlayable = false;
            animator.SetBool("isUsable", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag() {
        if (isPlayable)
        {
            startPosition = transform.position;
            isDragging = true;
        }
    }

    public void EndDrag() {
        isDragging = false;
        if (isPlayable)
        {
            if (isOverDropZone)
            {

                if (cardManager.playCard(cardId))
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("not enough stamina");
                    transform.position = startPosition;
                }

            }
            else
            {
                transform.position = startPosition;
            }
        }
    }
}
