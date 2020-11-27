using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DB", menuName = "Cards/CardsDB")]
public class CardDatabase : ScriptableObject
{
    public List<Card> cardList = new List<Card>();
}
