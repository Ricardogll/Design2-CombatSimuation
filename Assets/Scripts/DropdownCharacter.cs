using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownCharacter : MonoBehaviour
{
    private Dropdown drop;
    public PlayerControl p_control;
    public Turn turn;
    public DropdownAction drop_action;
    

    bool first_frame = true;


    // Start is called before the first frame update
    void Start()
    {
        drop = GetComponent<Dropdown>();


    }


    // Update is called once per frame
    private void Update()
    {

        if (first_frame)
        {
            first_frame = false;
            UpdateOptionsDropdownCharacters(0);
        }

    }
   


    public void UpdateOptionsDropdownCharacters(int value)
    {
        
        List<string> targets = new List<string>();
        bool target_enemy = p_control.player_characters[p_control.current_char].PossibleActions[value].targets_enemy;

        for (int i = 0; i < turn.characters.Count; i++)
        {
            if(turn.characters[i].enemy == target_enemy )
                targets.Add(turn.characters[i].char_name);
        }

        drop.ClearOptions();
        drop.AddOptions(targets);


        

    }


    

}
