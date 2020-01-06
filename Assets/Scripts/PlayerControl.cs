using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selection
{

    public Character this_char = null;
    public Character target_char = null;
    public BattleAction action = null;

}

public class PlayerControl : MonoBehaviour
{

    Text char_text;
    public Turn turn;
    [HideInInspector] public Selection player0_selection = new Selection();
    [HideInInspector] public Selection player1_selection = new Selection();
    [HideInInspector] public Selection player2_selection = new Selection();
    public DropdownAction drop_act;
    public DropdownCharacter drop_char;
    private Dropdown ui_dropdown_act;
    private Dropdown ui_dropdown_char;
    public int current_char = 0;
    public List<Character> player_characters;

    // Start is called before the first frame update
    void Start()
    {
        char_text = GetComponent<Text>();
        player_characters = GetPlayerCharacters();


        GameObject go = GameObject.Find("SelectAction");
        if (go)
            ui_dropdown_act = go.GetComponent<Dropdown>();
        

       GameObject go2 = GameObject.Find("SelectEnemy");
        if (go2)
            ui_dropdown_char = go2.GetComponent<Dropdown>();
        

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
        switch (current_char)
        {
            case 0:
                player0_selection.this_char = player_characters[0];
                player0_selection.action = player_characters[0].PossibleActions[ui_dropdown_act.value];
                player0_selection.target_char = GetTargetCharacter(ui_dropdown_char.value, player0_selection.action.targets_enemy);
                Debug.Log(player0_selection.this_char.char_name + " " + player0_selection.action.action_name + " " + player0_selection.target_char.char_name);
                break;

            case 1:
                player1_selection.this_char = player_characters[1];
                player1_selection.action = player_characters[1].PossibleActions[ui_dropdown_act.value];
                player1_selection.target_char = GetTargetCharacter(ui_dropdown_char.value, player1_selection.action.targets_enemy);
                Debug.Log(player1_selection.this_char.char_name + " " + player1_selection.action.action_name + " " + player1_selection.target_char.char_name);
                break;

            case 2:
                player2_selection.this_char = player_characters[2];
                player2_selection.action = player_characters[2].PossibleActions[ui_dropdown_act.value];
                player2_selection.target_char = GetTargetCharacter(ui_dropdown_char.value, player2_selection.action.targets_enemy);
                Debug.Log(player2_selection.this_char.char_name + " " + player2_selection.action.action_name + " " + player2_selection.target_char.char_name);
                break;
                
        }

        

        current_char++;
        if (current_char > 1) //CHANGE TO 2 IF 3vs3
            current_char = 0;

        drop_act.UpdateOptionsDropdown();
        drop_char.UpdateOptionsDropdownCharacters(0);

        //if current char > .... look that if its the last player do the turns ***************************************************************************
    }

    private Character GetTargetCharacter(int value, bool target_enemy)
    {
        
        int aux_value = 0;

        for (int i = 0; i < turn.characters.Count; i++)
        {
            if (turn.characters[i].enemy == target_enemy)
            {
                if (aux_value == value)
                    return turn.characters[i];

                aux_value++;
            }

        }
        
            return null;
    }

    
}
