using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public Turn turn;
    public bool start_turn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start_turn)
        {
            start_turn = false;
            Debug.Log("------- New Turn --------");
            turn.OrderCharacters();
            turn.DoTurn();

        }

    }

    public void SetStartTurn()
    {
        start_turn = true;
    }
}
