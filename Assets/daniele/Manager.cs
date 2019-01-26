using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameObject house1;
    public GameObject house2;

    public float timeLeft = 20;

    // Start is called before the first frame update
    void Start()
    {
        // get players:
        Character[] myItems = FindObjectsOfType(typeof(Character)) as Character[];

        player1 = myItems[0].gameObject;
        player2 = myItems[1].gameObject;

        // get houses:
        GameObject[] Houses = GameObject.FindGameObjectsWithTag("house");
        house1 = Houses[0].gameObject;
        house2 = Houses[1].gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        // set a timer

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameOver();
        }
    }
    public int finalScore1 = -1;
    public int finalScore2 = -1;
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 100), "TimeLeft:" +Mathf.RoundToInt(timeLeft));
        if(finalScore1 != -1)
         GUI.Label(new Rect(800, 20, 150, 100), "finalScore:" + finalScore1);
        if (finalScore2 != -1)
            GUI.Label(new Rect(100, 20, 150, 100), "finalScore:" + finalScore2);
    }


    private void GameOver()
    {        
        // send player home
        player1.transform.position = house1.transform.position;
        player2.transform.position = house2.transform.position;

        // calculate score
        score score1 = player1.GetComponent(typeof(score)) as score;
        finalScore1 = score1.numObjects;
        score score2 = player2.GetComponent(typeof(score)) as score;
        finalScore2 = score2.numObjects;
    }
}
