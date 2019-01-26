using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    public GameObject cube;
    public float houseDistance;
    // Start is called before the first frame update
    void Start()
    {

        cube = GameObject.Find("Cube");
    }
    // Update is called once per frame
    void Update()
    {
        if ((cube.transform.position - transform.position).magnitude > houseDistance)
            label = true;
        else label = false;
    }
    bool label;
    void OnGUI()
    {
        if(label)
            GUI.Label(new Rect(100, 100, 100, 100), "torna a casaaaaaaa!");
    }
}
