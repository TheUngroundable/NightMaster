using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    public float panSpeed = 20f;
    public float speed = 10f;
    public float rotSpeed = 5f;
    public float pickingThreshold = 0.5f;

    public int scorePositionOnScreen;
    public string fordwardKey;
    public string backKey;
    public string rightKey;
    public string leftKey;
    public string pickKey;
    public string torchKey;

    public int numObjects = 0;

    void Update()
    {
        if (Input.GetKey(fordwardKey))
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(backKey))
        {
            transform.Translate(speed * Vector3.back * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(rightKey))
        {
            transform.Rotate(0, rotSpeed, 0);
        }
        if (Input.GetKey(leftKey))
        {
            transform.Rotate(0, -rotSpeed, 0);
        }


        // if in house, hp increase


        // picking logic-------------------------------------------------------------------
        if (Input.GetKey(pickKey))
        {
            GameObject pickable = FindClosestEnemy();
            if (pickable != null && (pickable.transform.position - transform.position).magnitude < pickingThreshold)
            {
                Destroy(pickable);
                numObjects++;
            }
        }
    }
    void OnGUI()
    {
            GUI.Label(new Rect(scorePositionOnScreen, 100, 100, 100), numObjects.ToString());
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
