using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class staminaAndHealthUpdate : MonoBehaviour
{

    public Text healthIndicator;
    public Text staminaIndicator;
    public Text shieldIndicator;

    private playerStaminaControler stamina;
    private playerHealthController health;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        stamina = player.GetComponent<playerStaminaControler>();
        health = player.GetComponent<playerHealthController>();  
    }

    // Update is called once per frame
    void Update()
    {
        healthIndicator.text = health.getHealth().ToString();
        staminaIndicator.text = stamina.getStamina().ToString();
        shieldIndicator.text = health.getShield().ToString();
    }
}
