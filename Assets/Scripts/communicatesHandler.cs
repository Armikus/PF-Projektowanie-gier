using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class communicatesHandler : MonoBehaviour
{
    private Animator anim;
    private Text text;
    private Button endTurnButton;
    public bool duringAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        endTurnButton = GameObject.Find("EndTurn").GetComponent<Button>();
        anim = gameObject.GetComponent<Animator>();
        text = gameObject.GetComponent<Text>();
    }

    // FightPhaseCommunicationFade
    public void showCommunicate(string communicate) {
		endTurnButton = GameObject.Find("EndTurn").GetComponent<Button>();
        anim = gameObject.GetComponent<Animator>();
        text = gameObject.GetComponent<Text>();
        if (!duringAnimation)
        {
            duringAnimation = true;
            text.text = communicate;
            anim.SetBool("fade", true);
           endTurnButton.interactable = false;
        }
    }

    public void resetState()
    {
        anim.SetBool("fade", false);
        duringAnimation = false;
        endTurnButton.interactable = true;

    }
}
