using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{

    private Light torcia;
    private bool status = true;
    public int intensityTorcia = 10;

    void Start() {
        torcia = GetComponent<Light>();
    }
    void Update() {
    }

    public void Toggle()
    {
        status = !status;
        if (status)
        {
            torcia.intensity = intensityTorcia;
        } else
        {
            torcia.intensity = 0;
        }
    }

}
