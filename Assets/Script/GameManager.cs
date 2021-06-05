using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static GameManager instance = null;

    public static GameManager Instance
    {
        get => instance;
    }

    [SerializeField] public string UserName;
    [SerializeField] public string Name;
    [SerializeField] public string ID;
    [SerializeField] public int Level;
    [SerializeField] public User _dataLocalUser;
    [SerializeField] public User DataLocalUser
    {
        get => _dataLocalUser;
        set
        {
            _dataLocalUser = value;
        }
    }

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


}
