using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAttack : BattleAction
{
    Character this_char;
    public int buff_value;
    public int buff_duration = 3;

    // Start is called before the first frame update
    void Start()
    {
        this_char = GetComponent<Character>();
        targets_enemy = false;
        action_name = "Fortify";
    }


    public override void Execute(Character attacked_char)
    {
        if (attacked_char != null)
        {
            Debug.Log(this_char.char_name + " increases attack of " + attacked_char.char_name + " by: " + buff_value.ToString() + "%");
            attacked_char.IncreaseAttack(buff_value, buff_duration);

        }
    }
}
