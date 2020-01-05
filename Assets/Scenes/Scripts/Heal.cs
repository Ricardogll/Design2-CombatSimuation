using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : BattleAction
{
    Character this_char;

    // Start is called before the first frame update
    void Start()
    {
        this_char = GetComponent<Character>();
        targets_enemy = false;
    }


    public override void Execute(Character attacked_char)
    {
        if (attacked_char != null)
        {
            Debug.Log(this_char.name + " HEALING " + attacked_char.name + ": " + this_char.attack.ToString());
            attacked_char.ChangeHP(this_char.attack);
        }
    }

}
