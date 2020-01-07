using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : BattleAction
{

    Character this_char;
    public int damage = -10;

    // Start is called before the first frame update
    void Start()
    {
        this_char = GetComponent<Character>();
        targets_enemy = false;
        action_name = "Trap";
    }


    public override void Execute(Character attacked_char)
    {
        if (attacked_char != null && this_char.hp > 0)
        {
            if (attacked_char.trapped)
            {
                Debug.Log(this_char.char_name + " tries putting a trap in front of " + attacked_char.char_name + " but there is already one");


            }
            else
            {
                Debug.Log(this_char.char_name + " puts a trap in front of " + attacked_char.char_name);
                attacked_char.trapped = true;
            }
        }
    }

}
