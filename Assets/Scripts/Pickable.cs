using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("porcodio");
            other.gameObject.GetComponent<Player>().hasPickable = true;
            GameObject.Destroy(gameObject);
        }
    }
}