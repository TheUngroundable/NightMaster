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
    int objCount = 0;
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
            
            if ( (pickable != null)&&(pickable.transform.position - transform.position).magnitude < pickingThreshold)
            {
                objCount++;
                Destroy(pickable);
            }
        }

    }
    void OnGUI()
    {
            GUI.Label(new Rect(200, 100, 100, 100), objCount.ToString());
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
