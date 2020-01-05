using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BattleAction
{
    Character this_char;

    // Start is called before the first frame update
    void Start()
    {
        this_char = GetComponent<Character>();
    }


    public override void Execute(Character attacked_char)
    {
        if (attacked_char != null)
        {
            int damage = -this_char.attack + attacked_char.defense;

            if (damage > 0)
                damage = 0;

            Debug.Log(this_char.name + " ATTACKING " + attacked_char.name + ": " + damage.ToString());
            attacked_char.ChangeHP(damage);
        }
    }

}
