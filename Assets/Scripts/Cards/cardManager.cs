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

    public bool isCardPlayable(int cardId) {
        if (stamina.getStamina() < allCards.cardList[cardId].cost) return false;
        return true;
    }

    public bool playCard(int cardId) {
        Card playedCard = allCards.cardList[cardId];
        int cost = playedCard.cost;
        if (stamina.useStamina(cost)) {
            /*
             * CARD TYPES:
             * 0 SINGLE TARGET DAMAGE
             * 1 AOE DAMAGE
             * 2 SHIELD
             */
            switch (playedCard.type) {
                case 0: 
                    dealSingleTargetDamage(playedCard.damage);
                    break;
                case 1:
                    dealDamageToEveryone(playedCard.damage);
                    break;
                case 2:
                    addShield(playedCard.damage);
                    break;
                default:
                    dealSingleTargetDamage(playedCard.damage);
                    break;
            }

            deckController.addToPlayed(playedCard.id);

            return true;
        }
        else return false;
    }

    private void dealSingleTargetDamage(int damage)
    {
        enemyControler.takeDamage(damage, true);
    }

    private void dealDamageToEveryone(int damage) {
        enemyControler.takeDamage(damage, false);
    }

    private void addShield(int ammount) {
        health.addShield(ammount);
    }
}
