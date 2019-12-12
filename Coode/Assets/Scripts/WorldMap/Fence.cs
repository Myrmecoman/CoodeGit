﻿using UnityEngine;

public class Fence : MonoBehaviour
{
    public bool open;
    public Material red;
    public Material green;

    private MeshRenderer screen;


    private void Start()
    {
        open = false;
        screen = GetComponent<MeshRenderer>();
    }


    public void OnChange()
    {
        open = !open;
        if (open)
        {
            screen.materials[2] = green;
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            screen.materials[2] = red;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
