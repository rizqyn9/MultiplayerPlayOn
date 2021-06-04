using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class User : MonoBehaviour
{
    [SerializeField] private string _id;
    public string ID
    {
        get => _id;
        set {
            _id = value;
        }
    }
    private string _userName;
    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
        }
    }
    private int _level;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
        }
    }
}