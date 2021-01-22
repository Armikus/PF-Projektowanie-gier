using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControler : MonoBehaviour
{
    public EnemyDatabase allEnemies;
    public GameObject Enemy;

    private List<Enemy> enemiesOnBattlefied = new List<Enemy>();
    private List<enemyStatsHandler> enemiesHandlers = new List<enemyStatsHandler>();
    private playerHealthController healthController;
    private GameObject EnemyArea;

    private int deadEnemies;
    private int numberOfEnemies;

    public int selectedTarget;

    void Start() {
        healthController = GameObject.Find("Player").GetComponent<playerHealthController>();
        deadEnemies = 0;
        EnemyArea = GameObject.Find("EnemyArea");
        selectedTarget = 0;
    }

    public void startBattle() {
        selectEnemiesForBattle();
        showEnemies();
    }

    void selectEnemiesForBattle() { 
        numberOfEnemies = Random.Range(1, 4);
        for (int i = 0; i < numberOfEnemies; i++) {
            enemiesOnBattlefied.Add(allEnemies.enemies[Random.Range(0, allEnemies.enemies.Count)]);
        }
    }

    void showEnemies() {
        GameObject temp = null;
        for (int i = 0; i < enemiesOnBattlefied.Count; i++) { 
            temp = Instantiate(enemiesOnBattlefied[i].prefab, new Vector2(0,0), Quaternion.identity);
            enemiesOnBattlefied[i].fillTemplate(temp);

            enemyStatsHandler tempHandler = temp.GetComponent<enemyStatsHandler>();
            tempHandler.loadEnemyInformations();
            tempHandler.instanceId = i;

            enemiesHandlers.Add(tempHandler);

            temp.transform.SetParent(EnemyArea.transform, false);
        }
        selectedTarget = numberOfEnemies - 1;
    }

    public bool thereAreEnemiesLeft() {
        if (deadEnemies == numberOfEnemies) return false;
        else return true;
    }

    public void takeDamage(int damage, bool singleTarget) {
        if (selectedTarget != null)
        {
            if (singleTarget)
            {
                if (enemiesHandlers[selectedTarget].takeDamage(damage)){ }
                else
                {
                    deadEnemies++;
                    selectNewTarget();
                }
            }
            else {
                foreach (enemyStatsHandler enemy in enemiesHandlers) {
                    if (!enemy.takeDamage(damage)) {
                        deadEnemies++;
                        selectNewTarget();
                    }
                }
            }
        }
    }

    public void makeTurn() {
        foreach (enemyStatsHandler s in enemiesHandlers) {
            if (!s.isDead())
            {
                healthController.TakeDamage(s.getDamage());
            }
        }
    }

    public bool checkIfDead(int id) {
        return enemiesHandlers[id].isDead();
    }

    private void selectNewTarget() {
        GameObject cursorArea = GameObject.Find("PointerArea");
        if (deadEnemies < numberOfEnemies)
        {
            selectedTarget = enemiesHandlers.Find(c => c.isDead() == false).instanceId;
        }
        else selectedTarget = -1;

        foreach (Transform child in cursorArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public List<Enemy> getEnemies() {
        return enemiesOnBattlefied;
    }

    public void setEnemiesOnBattlefield(List<Enemy> enemies) {
        enemiesOnBattlefied = enemies;
        showEnemies();
    }
}
