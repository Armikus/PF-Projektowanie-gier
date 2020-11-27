using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    private int healthInitial = 30;
    private int healthCurrent;
    // Start is called before the first frame update

    public void resetHealth() {
        healthCurrent = healthInitial;
    }

    public void TakeDamage(int damageAmount) {
        healthCurrent -= damageAmount;
        if (healthCurrent <= 0) {
            Debug.Log("player is dead");
        }
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
