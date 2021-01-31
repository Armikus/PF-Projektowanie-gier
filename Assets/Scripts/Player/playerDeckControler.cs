using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeckControler : MonoBehaviour
{
    public GameObject Card;
    public CardDatabase allCards;
    public GameObject PlayerHand;


    private List<Card> playerDeck;
    private List<Card> cardsDead = new List<Card>();
    private List<Card> cardsAvaiable;
    private List<Card> playedCards = new List<Card>();

    private List<Card> playerHand;
    private List<GameObject> cardsPrefabs;
    public int handSize;

    public void initialize(){
        int sizeOfCardsList = allCards.cardList.Count;

        playerDeck = new List<Card>(sizeOfCardsList);
        cardsAvaiable = new List<Card>(sizeOfCardsList);
        playerHand = new List<Card>(handSize);
        cardsPrefabs = new List<GameObject>(handSize);
        buildDeck();
    }

    void buildDeck() {
        for (int i = 0; i < 20; i++)
        {
            foreach (Card c in allCards.cardList)
            {
                playerDeck.Add(c);
                cardsAvaiable.Add(c);
            }
        }
    }

    public void showHand() {
        GameObject playerCard;
        Card temp;
        for (int i = 0; i < handSize; i++)
        {
            temp = drawCard();
            if (temp != null)
            {
                playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
                temp.fillTemplate(playerCard);

                cardsPrefabs.Add(playerCard);
                playerCard.transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
                playerCard.transform.SetParent(PlayerHand.transform, false);
            }
        }
    }

    private Card drawCard() {
        Card temp = null;
        if (cardsAvaiable.Count >= 1)
        {
            int id = Random.Range(0, cardsAvaiable.Count);
            temp = cardsAvaiable[id];

            removeFromAvaiable(temp.id);
            addToHand(temp.id);
        }
        else
        {
            Debug.Log("Brak kart");
            Application.LoadLevel(4);
        }
        return temp;
    }

    private void removeFromAvaiable(int id) {
        cardsAvaiable.Remove(cardsAvaiable.Find(c => c.id == id));
    }

    private void addToHand(int id){
        playerHand.Add(allCards.cardList[id]);
    }

    public void discardHand() {
        foreach (GameObject o in cardsPrefabs) {
            Destroy(o);
        }
        playerHand.Clear();
    }

    public void addToPlayed(int id){
        playedCards.Add(allCards.cardList[id]);
        discardCard(id);
    }

    public void discardCard(int id){
        cardsDead.Add(allCards.cardList[id]);
    }
}
