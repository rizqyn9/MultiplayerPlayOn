using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class LocalDataPlayer : MonoBehaviour
{
    [SerializeField]
    public static LocalDataPlayer instance = null;

    [SerializeField] public string UserName;
    [SerializeField] public string Name;
    [SerializeField] public string ID;
    [SerializeField] public int Level;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public static LocalDataPlayer Instance
    {
        get => instance;
    }
}
