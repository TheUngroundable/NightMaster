using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public int point;
    public int playerHome;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<Player>().hasPickable)
        {
            point++;
            other.gameObject.GetComponent<Player>().hasPickable = false;
        }
    }
}
