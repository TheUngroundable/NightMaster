using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject torch;
    public GameObject diffusion;
    public bool status = true;

    public void Toggle()
    {
        status = !status;
        if (status)
        {
            torch.SetActive(true);
            diffusion.SetActive(true);
        } else
        {
            torch.SetActive(false);
            diffusion.SetActive(false);
        }
    }
}
