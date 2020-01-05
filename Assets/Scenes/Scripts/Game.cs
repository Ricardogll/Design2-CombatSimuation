﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public Turn turn;
    public bool start_game = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start_game)
        {
            start_game = false;

            turn.OrderCharacters();
            turn.DoTurn();

        }

    }
}
