using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction : MonoBehaviour
{
    [HideInInspector]
    public string action_name = "Default";
    [HideInInspector]
    public bool targets_enemy = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void Execute(Character activeCharacter)
    {

    } 
}
