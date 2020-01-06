using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction : MonoBehaviour
{
    [HideInInspector]
    public string action_name = "Default";
    [HideInInspector]
    public bool targets_enemy = true;
    


    virtual public void Execute(Character activeCharacter)
    {

    } 
}
