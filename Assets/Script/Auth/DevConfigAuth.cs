using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevConfigAuth : DevConfig
{
    [AddComponentMenu("")]
    public bool Reset = false;

    public void Start()
    {
        if (isDevMode)
        {
            if (Reset)
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }
}
