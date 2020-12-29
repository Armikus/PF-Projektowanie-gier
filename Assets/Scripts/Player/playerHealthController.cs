using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    private int healthInitial = 30;
    private int healthCurrent;
    private int shieldCurrent = 5;
    // Start is called before the first frame update

    public void resetHealth() {
        healthCurrent = healthInitial;
        shieldCurrent = 5;
    }

    public void TakeDamage(int damageAmount) {
        int damage = damageAmount - shieldCurrent;
        if (damage > 0) healthCurrent -= damage;

        shieldCurrent -= damageAmount;
        if (shieldCurrent < 0) shieldCurrent = 0;
        if (healthCurrent <= 0) Debug.Log("player is dead");      
    }

    public void Heal(int healAmount) {
        healthCurrent += healAmount;
        if (healthCurrent > healthInitial) {
            resetHealth();
        }
    }

    public bool isAlive() {
        if (healthCurrent > 0) return true;
        else return false;
    }

    public int getHealth() { return healthCurrent; }
    public int getShield() { return shieldCurrent; }

    public void addShield(int ammount) { shieldCurrent += ammount; }
    // Update is called once per frame
    void Update()
    {
        
    }
}
