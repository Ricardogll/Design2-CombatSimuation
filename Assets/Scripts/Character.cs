﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string char_name = "Name";
    public bool enemy = false;
    public int level = 1;
    public int hp;
    public int attack;
    public int defense;
    public int healing;
    public int speed;
    public int healing_charges = 2;
    //public List<BattleAction> AllActions;
    public List<BattleAction> PossibleActions;

    public bool main_stat_hp = false;
    public bool main_stat_attack = false;
    public bool main_stat_speed = false;

    [HideInInspector] public bool trapped = false;
    [HideInInspector] public int attack_buff = 0;
    [HideInInspector] public int at_buff_turns = 0;
    [HideInInspector] public int base_attack = 0;

    [HideInInspector] public int base_hp = 0;
    

    public BattleAction ChooseRandAction()
    {
        return PossibleActions[Random.Range(0, PossibleActions.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {

        if (main_stat_hp)
            hp += 3 / 2 * (level - 1);
        else
            hp += level - 1;

        if (main_stat_attack)
            attack += 3 / 2 * (level - 1);
        else
            attack += level - 1;

        if (main_stat_speed)
            speed += 3 / 2 * (level - 1);
        else
            speed += level - 1;

        defense += (level - 1) / 2;

        base_attack = attack;
        base_hp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeHP(int x, bool is_heal = false)
    {
        if ((is_heal && healing_charges > 0) || !is_heal)
        {
            if (hp + x > base_hp)
                hp = base_hp;
            else
                hp += x;

            if (hp < 0)
                hp = 0;


        }
    }

    public void IncreaseAttack(int buff_value, int buff_duration)
    {

        if(attack_buff <= 0)
        {
            attack_buff = buff_value;
            attack += (attack * buff_value / 100);
            
        }

        at_buff_turns = buff_duration;
    }

    public void ResetAttack()
    {
        attack = base_attack;
        attack_buff = 0;
    }
}
