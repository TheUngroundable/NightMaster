using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float panSpeed = 20f;
    public float speed = 10f;
    public float pickingThreshold = 0.5f;
    void Update()
    {

        if (Input.GetKey("w"))
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(speed * Vector3.back * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 1, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey("space"))
        {
            GameObject pickable = FindClosestEnemy();
            if ((pickable.transform.position - transform.position).magnitude < pickingThreshold)
            {
               // pickable.des
            }
        }

    }

    // Find the name of the closest enemy

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("pickable");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
