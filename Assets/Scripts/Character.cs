using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name = "Name";
    public bool enemy = false;
    public int hp;
    public int attack;
    public int defense;
    public int speed;
    public List<BattleAction> AllActions;
    public List<BattleAction> PossibleActions;


    public BattleAction ChooseRandAction()
    {
        return PossibleActions[Random.Range(0, PossibleActions.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeHP(int x)
    {
        hp += x;
    }
}
