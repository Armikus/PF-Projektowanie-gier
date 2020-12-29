using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyStatsHandler : MonoBehaviour
{
    public EnemyDatabase allEnemies;

    public int instanceId;
    private int sourceId;
    private int hp;
    private int maxHp;
    private int minDmg;
    private int maxDmg;

    private Animator animator;

    private Sprite art;
    private string name;
    private bool dead = false;


    void Start() { 
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void loadEnemyInformations() {
        Text[] idField = gameObject.GetComponentsInChildren<Text>();

        for (int i = 0; i < idField.Length; i++)
        {
            if (idField[i].name == "Id")
            {
                sourceId = Int32.Parse(idField[i].text);
                Enemy temp = allEnemies.enemies[sourceId];
                maxHp = temp.maxHp;
                hp = maxHp;
                minDmg = temp.minDmg;
                maxDmg = temp.maxDmg;
                name = temp.name;
                art = temp.art;
            }
        }
    }

    public void fillDetailsTemplate(GameObject template)
    {
        if (!dead) {
            GameObject temp = template.transform.GetChild(0).GetChild(0).gameObject;
            Text[] textFields = temp.GetComponentsInChildren<Text>();
            for (int i = 0; i < textFields.Length; i++)
            {
                if (textFields[i].name == "Name")
                {
                    textFields[i].text = name;
                }

                else if (textFields[i].name == "Health")
                {
                    textFields[i].text = "HP: " + hp + " / " + maxHp;
                }

                else if (textFields[i].name == "Damage")
                {
                    textFields[i].text = "DMG: " + minDmg + " - " + maxDmg;
                }
            }
        }
    }

    public bool takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = maxHp;
            die();
            return false;
        }
        else
        {
            return true;
        }
    }

    public int getDamage() {
        playAttackAnimation();
        System.Random rng = new System.Random();
        return (rng.Next(minDmg, maxDmg));
    }

    private void playAttackAnimation() {
        animator.SetBool("isAttacking", true);
    }

    private void die()
    {
        Debug.Log(name + " died");
        dead = true;

        animator.SetBool("isDead", true);

        /*foreach (Transform child in gameObject.transform) {
            child.gameObject.SetActive(false);
        }*/

        //Destroy(gameObject);
    }

    public bool isDead()
    {
        return dead;
    }
}
