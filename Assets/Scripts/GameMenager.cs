using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public GameObject pickable;
    public GameObject[] pickableSpawnPoint;
    public const float gameTime = 100.0f;
    public float currentGameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGameTime = Time.time;
        if (currentGameTime > gameTime)
        {
            Debug.Log("fine gioco");
        }

        //currentgametime parte da 0, quando arriva a 3 inizia il gioco attiva player script
    }
}
