using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationDealer : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void attackAnimationFinished()
    {
        animator.SetBool("isAttacking", false);
    }
}
