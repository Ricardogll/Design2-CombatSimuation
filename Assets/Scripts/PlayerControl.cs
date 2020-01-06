using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selection
{

    Character this_char;
    Character taraget_char;
    BattleAction action;

}

public class PlayerControl : MonoBehaviour
{

    Text char_text;
    public Turn turn;
    Selection player1_selection;


    private List<Character> player_characters;

    // Start is called before the first frame update
    void Start()
    {
        char_text = GetComponent<Text>();
        player_characters = GetPlayerCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private List<Character> GetPlayerCharacters()
    {
        List<Character> players = new List<Character>();

        for(int i = 0; i < turn.characters.Count; i++)
        {

            if (!turn.characters[i].enemy)
            {
                players.Add(turn.characters[i]);
            }

        }
        

        return players;
    }


    public void SelectButtonClicked()
    {

        //Fill Selection

    }


    
}
