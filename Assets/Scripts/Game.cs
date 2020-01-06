using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public Turn turn;
    public bool start_turn = false;

  
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

    public void StartSceneAI()
    {
        SceneManager.LoadScene("IAvsIA");

    }

    public void StartScenePLAYER()
    {
        SceneManager.LoadScene("PLAYERvsIA");
    }

}
