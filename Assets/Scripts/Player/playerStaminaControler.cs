using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStaminaControler : MonoBehaviour
{
    private int staminaInitial = 3;
    private int staminaCurrent;
    // Start is called before the first frame update
    void Start()
    {
        ResetStamina();
    }

    public void ResetStamina() {
        staminaCurrent = staminaInitial;
    }

    public bool useStamina(int ammount) {
        if (ammount <= staminaCurrent)
        {
            staminaCurrent -= ammount;
            return true;
        }
        else {
            return false;
        }
    }


    public int getStamina() { return staminaCurrent; }

    void Update()
    {
    }
}
