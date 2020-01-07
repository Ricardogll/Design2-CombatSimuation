using System.Collections;
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

            string char_text = character.char_name + " Lvl. " + character.level.ToString() + "\n\n"
                + "HP: " + character.hp.ToString() + "\n"
                + "Attack: " + character.attack.ToString() + "\n"
                + "Defense: " + character.defense.ToString() + "\n"
                + "Speed: " + character.speed.ToString() + "\n"
                + "(" + character.healing_charges + ") " + "Item Heal: " + character.healing.ToString() + "HP\n\n"
                + "ACTIONS";

            for (int i = 0; i < character.PossibleActions.Count; i++)
            {

                char_text += "\n" + character.PossibleActions[i].action_name;

            }

            char_text += "\n\nSTATUS";

            if (character.at_buff_turns > 0)
            {
                char_text += "\nAttack +" + character.attack_buff + "%";

            }
            else
            {
                char_text += "\nNone";
            }
            

            text.text = char_text;
        }
    }
}
