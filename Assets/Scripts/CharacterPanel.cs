﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{

    Text text = null;
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {

            string char_text = character.name + "\n\n"
                + "HP: " + character.hp.ToString() + "\n"
                + "Attack: " + character.attack.ToString() + "\n"
                + "Defense: " + character.defense.ToString() + "\n"
                + "Speed: " + character.speed.ToString() + "\n\n"
                + "ACTIONS";

            for (int i = 0; i < character.PossibleActions.Count; i++)
            {

                char_text += "\n" + character.PossibleActions[i].action_name;

            }


            text.text = char_text;
        }
    }
}
