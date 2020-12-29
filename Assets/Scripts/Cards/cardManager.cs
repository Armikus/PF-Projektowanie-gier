using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardManager : MonoBehaviour
{
    public CardDatabase allCards;
    private playerStaminaControler stamina;
    private playerHealthController health;
    private playerDeckControler deckController;
    private enemyControler enemyControler;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        stamina = player.GetComponent<playerStaminaControler>();
        health = player.GetComponent<playerHealthController>();
        deckController = player.GetComponent<playerDeckControler>();

        enemyControler = GameObject.Find("GameManager").GetComponent<enemyControler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isCardPlayable(int cardId) {
        if (stamina.getStamina() < allCards.cardList[cardId].cost) return false;
        return true;
    }

    public bool playCard(int cardId) {
        Card playedCard = allCards.cardList[cardId];
        int cost = playedCard.cost;
        if (stamina.useStamina(cost)) {

            int damage = playedCard.damage;

            enemyControler.takeDamage(damage);
            deckController.addToPlayed(playedCard.id);

            return true;
        }
        else return false;
    }
}
