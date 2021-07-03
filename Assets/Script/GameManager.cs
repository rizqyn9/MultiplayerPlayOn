using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static GameManager instance = null;

    public string UserName;
    public string Name;
    public string ID;
    public int Level;
    public CharTypeEnum CharID;
    public Room DataRoom;

    // Set Online Player
    public uint NetID;

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

    public static GameManager Instance
    {
        get => instance;
    }
}
