using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Turn : MonoBehaviour
{
    public List<Character> characters;

    public Turn(List<Character> chars)
    {
        characters = chars;
    }


    public void OrderCharacters()
    {

        //characters.OrderByDescending(x => x.speed);
        


        List<int> speed_chars = new List<int>();

        for (int i = 0; i < characters.Count; i++)
        {
            speed_chars.Add(characters[i].speed);
        }

        speed_chars.Sort();
        speed_chars.Reverse();

        List<Character> aux = new List<Character>();

        for(int i = 0; i < characters.Count; i++)
        {
            for (int j = 0; j < characters.Count; j++)
            {
                if (speed_chars[i] == characters[j].speed && !aux.Contains(characters[j]))
                {
                    
                    aux.Add(characters[j]);
                    continue;
                }
            }
        }

        characters = aux;

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].hp <= 0)
                characters.RemoveAt(i);
        }

    }

    public void PlayerVSIADoTurn(Selection p0, Selection p1)
    {
        OrderCharacters();

        int index_p0 = characters.IndexOf(p0.this_char), index_p1 = characters.IndexOf(p1.this_char);

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].enemy)
            {
                BattleAction action = characters[i].ChooseRandAction();

                if (action.targets_enemy)
                    action.Execute(ChooseRandEnemy(characters[i].enemy));
                else
                    action.Execute(ChooseRandEnemy(!characters[i].enemy));

            }
            else
            {

                if (i == index_p0)
                    p0.action.Execute(p0.target_char);
                else
                {
                    if (i == index_p1)
                        p1.action.Execute(p1.target_char);
                }

            }

        }
    }

   

    public void DoTurn()
    {//All turn in 1 go (IA vs IA)

        for(int i = 0; i < characters.Count; i++)
        {
            BattleAction action = characters[i].ChooseRandAction();

            if(action.targets_enemy)
                action.Execute(ChooseRandEnemy(characters[i].enemy));
            else
                action.Execute(ChooseRandEnemy(!characters[i].enemy));
        }

        LowerBuffTimers();
    }



    private Character ChooseRandEnemy(bool team) //Pass team of the character attacking
    {

        List<Character> enemies = new List<Character>();

        for(int i = 0; i < characters.Count; i++)
        {
            if (characters[i].enemy != team)
            {//See if they are on the same team (enemies vs heroes)
                enemies.Add(characters[i]);
            }

        }

        if (enemies.Count == 0)
        {
            Debug.Log("THERE ARE NO CHARACTERS ON THE OPPOSITE TEAM, GAME DONE.\nRestart above ^^^^");
            return null;
        }

        return enemies[Random.Range(0, enemies.Count)];
    }


    private void LowerBuffTimers()
    {

        for (int i = 0; i < characters.Count; i++)
        {

            if (characters[i].at_buff_turns > 0)
            {
                characters[i].at_buff_turns--;

                if(characters[i].at_buff_turns == 0)
                {
                    characters[i].ResetAttack();
                }

            }

        }


    }
}


