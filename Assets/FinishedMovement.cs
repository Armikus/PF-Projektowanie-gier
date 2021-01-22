using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedMovement : MonoBehaviour
{
    public void clearMovementState()
    {
        gameObject.GetComponent<Animator>().SetBool("isMoving", false);
    }
}
