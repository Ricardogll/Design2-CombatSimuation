using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownAction : MonoBehaviour
{

    private Dropdown drop;
    public PlayerControl p_control;
    public Turn turn;
    public int current_char = 0;

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
            UpdateOptionsDropdown();
        }

    }
    //drop.onValueChanged


    public void AddOptionsToDropdown()
    {



    }

    public void UpdateOptionsDropdown()
    {
        List<string> actions = new List<string>();

        for(int i = 0; i < turn.characters[current_char].PossibleActions.Count; i++)
        {
            actions.Add(turn.characters[current_char].PossibleActions[i].action_name);
        }

        drop.ClearOptions();
        drop.AddOptions(actions);

    }
}
