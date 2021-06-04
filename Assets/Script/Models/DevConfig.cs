using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DevConfig : MonoBehaviour
{
    public static DevConfig instance;

    public bool isDevMode = true;

    private void Start()
    {
        if (isDevMode)
        {
            Debug.Log("Running Developer Mode");
        } else
        {
            Debug.Log("Running Production");
        }

    }

}
