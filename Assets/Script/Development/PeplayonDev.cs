using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class DevConfiguration
{
    const string runningFromMainMenu = "Peplayon / Running from main menu";

    [MenuItem(runningFromMainMenu, false)]
    static bool Test()
    {
        Debug.Log("haha");
        return true;
    }
}