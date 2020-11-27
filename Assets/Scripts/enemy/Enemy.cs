using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/Enemy")]
public class Enemy : ScriptableObject
{
    public int id;
    public int maxHp;
    public int minDmg;
    public int maxDmg;

    public new string name;

    public Sprite art;


    public void fillTemplate(GameObject template)
    {
        Text[] textFields = template.GetComponentsInChildren<Text>();
        for (int i = 0; i < textFields.Length; i++)
        {
            if (textFields[i].name == "Id")
            {
                textFields[i].text = id.ToString();
            }
        }


        SpriteRenderer[] arts = template.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < arts.Length; i++)
        {
            if (arts[i].name == "Art")
            {
                arts[i].sprite = art;
            }
        }
    }

}
