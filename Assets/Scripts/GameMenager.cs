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

    // Update is called once per framse
    void Update()
    {
        currentGameTime = Time.time;
        if (currentGameTime > gameTime)
        {
            Debug.Log("fine gioco");
        }
    }
}
