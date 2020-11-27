using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName="Cards/Card")]
public class Card : ScriptableObject{
    public int id;
    public new string name;
    public string description;

    public Sprite artwork;

    public int cost;
    public int damage;

    public void fillTemplate(GameObject template)
    {
        Text[] textFields = template.GetComponentsInChildren<Text>();
        for (int i = 0; i < textFields.Length; i++) {
            if (textFields[i].name == "Title")
            {
                textFields[i].text = name;
            }

            else if (textFields[i].name == "Description")
            {
                textFields[i].text = description;
            }

            else if (textFields[i].name == "Cost") {
                textFields[i].text = cost.ToString();
            }

            else if (textFields[i].name == "Id")
            {
                textFields[i].text = id.ToString();
            }


        }


        Image[] arts = template.GetComponentsInChildren<Image>();
        for (int i = 0; i < arts.Length; i++)
        {
            if (arts[i].name == "Art")
            {
                arts[i].sprite = artwork;
            }
        }
    }
  
}
