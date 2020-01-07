using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BattleAction
{
    Character this_char;
    Trap trap;

    // Start is called before the first frame update
    void Start()
    {
        trap = GetComponent<Trap>();
        this_char = GetComponent<Character>();
        action_name = "Attack";
    }


    public override void Execute(Character attacked_char)
    {
        if (attacked_char != null && this_char.hp > 0)
        {
            int damage = -this_char.attack + attacked_char.defense;

            if (damage > 0)
                damage = 0;

            Debug.Log(this_char.char_name + " attacking " + attacked_char.char_name + ": " + damage.ToString());
            attacked_char.ChangeHP(damage);

            if (attacked_char.trapped)
            {

                Debug.Log("(!) A trap is triggered in front of " + attacked_char.char_name + " and " 
                    + this_char.char_name + " takes " + trap.damage.ToString() + " dmg");
                this_char.ChangeHP(trap.damage);

                attacked_char.trapped = false;

            }

        }
    }

}
