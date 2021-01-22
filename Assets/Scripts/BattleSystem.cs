using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public BattleState state;

    private playerHealthController playerHealth;
    private playerStaminaControler playerStamina;
    private enemyControler enemies;
    private playerDeckControler cardController;
    private communicatesHandler playerCommunication;

    public GlobalController GlobalData;

    void Start()
    {
        GlobalData = GameObject.Find("GlobalData").GetComponent<GlobalController>();
        playerHealth = GameObject.Find("Player").GetComponent<playerHealthController>();
        playerStamina = GameObject.Find("Player").GetComponent<playerStaminaControler>();
        cardController = GameObject.Find("Player").GetComponent<playerDeckControler>();
        playerCommunication = GameObject.Find("Communicate").GetComponent<communicatesHandler>();

        GlobalData.setInFightState(true);

        enemies = GameObject.Find("GameManager").GetComponent<enemyControler>();

        playerHealth.setStartHealth(GlobalData.getPlayerHealth());

        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle() {
        if (GlobalData.getBattleContinuation())
        {
            enemies.setEnemiesOnBattlefield(GlobalData.getEnemies());
        }
        else enemies.startBattle();

        state = BattleState.PLAYERTURN;
        playerHealth.resetHealth();
        cardController.initialize();
        PlayerTurn();
    }

    void PlayerTurn() {
        if (playerHealth.isAlive())
        {
            playerCommunication.showCommunicate("Your Turn");
            playerStamina.ResetStamina();
            cardController.showHand();
        }
        else {
            state = BattleState.LOST;
            lost();
        }
    }

    public void endPlayerTurn() {
        state = BattleState.ENEMYTURN;
        cardController.discardHand();
        enemyTurn();
    }

    void enemyTurn() {
        if (enemies.thereAreEnemiesLeft())
        {
            enemies.makeTurn();
            PlayerTurn();
        }
        else {
            state = BattleState.WON;
            won();
        }
    }

    void won() {
        Debug.Log("Battle finished - You Won");
        playerCommunication.showCommunicate("You Won");
        GlobalData.SaveHp(playerHealth.getHealth());
        GlobalData.setBattleContinuation(false);
        Application.LoadLevel(2);
    }

    void lost() {
        Debug.Log("Battle finished - You Lost");
        playerCommunication.showCommunicate("Defeat");
        GlobalData.resetGlobalData();
        Application.LoadLevel(0);
    }


    public void saveFightState() {
        GlobalData.saveEnemies(enemies.getEnemies());
        GlobalData.setBattleContinuation(true);
        GlobalData.SaveHp(playerHealth.getHealth());
    }

    void Update()
    {
        if(state != BattleState.WON) {
            if (!playerCommunication.duringAnimation)
            {
                if (!enemies.thereAreEnemiesLeft())
                {
                    state = BattleState.WON;
                    won();
                }
            }
        }
    }
}
