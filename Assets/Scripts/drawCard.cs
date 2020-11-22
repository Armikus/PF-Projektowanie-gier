using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawCard : MonoBehaviour
{
    public GameObject Card;
    public GameObject PlayerHand;

    public CardDatabase Cards;

    public void addNewCardToHand() {
        GameObject playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
        Cards.cardList[Random.Range(0, Cards.cardList.Count)].fillTemplate(playerCard);
        playerCard.transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
        playerCard.transform.SetParent(PlayerHand.transform, false);
    }
}
