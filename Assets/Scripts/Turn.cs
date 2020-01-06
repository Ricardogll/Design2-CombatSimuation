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
        characters.OrderByDescending(x => x.speed);

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].hp <= 0)
                characters.RemoveAt(i);
        }

    }

    public void DoTurnChar(Character c)
    {
        //Turn for only 1 at a time
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
            Debug.Log("THERE ARE NO CHARACTERS ON THE OPPOSITE TEAM");
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


