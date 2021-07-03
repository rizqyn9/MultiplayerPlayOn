using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

//[InitializeOnLoad]
public class DevConfiguration : MonoBehaviour
{
    const string runningFromMainMenu = "Peplayon / Running from main menu";
    const string netStartServer = "Peplayon / Start Server";
    const string netStartClient = "Peplayon / Start Client";

    const string k_BootstrapSceneKey = "BootstrapScene";
    const string k_LoadBootstrapSceneKey = "LoadBootstrapScene";
    const string k_StartState = "StartState";
    const string k_PreviousSceneKey = "PreviousScene";

    #region bootstrap
    [MenuItem(runningFromMainMenu)]
    static void EnabledTest()
    {
        LoadBootstrapScene = true;
    }

    [MenuItem(runningFromMainMenu, true)]
    static bool NetStart()
    {
        return !LoadBootstrapScene;
    }
    #endregion

    #region Listeningg on event play editor
    static DevConfiguration()
    {
        //EditorApplication.playModeStateChanged += EditorApplicationOnplayModeStateChanged;
    }
    #endregion

    #region Set Pref Editor scene path
    static string BootstrapScene
    {
        get
        {
            if (!EditorPrefs.HasKey(k_BootstrapSceneKey))
            {
                EditorPrefs.SetString(k_BootstrapSceneKey, EditorBuildSettings.scenes[1].path);
            }
            return EditorPrefs.GetString(k_BootstrapSceneKey, EditorBuildSettings.scenes[1].path);
        }
        set => EditorPrefs.SetString(k_BootstrapSceneKey, value);
    }

    static string PreviousScene
    {
        get => EditorPrefs.GetString(k_PreviousSceneKey);
        set => EditorPrefs.SetString(k_PreviousSceneKey, value);
    }

    /// <summary>
    /// Default value
    /// if true playmode will start in main menu scene index == 1
    /// </summary>
    static bool LoadBootstrapScene
    {
        get
        {
            if (!EditorPrefs.HasKey(k_LoadBootstrapSceneKey))
            {
                EditorPrefs.SetBool(k_LoadBootstrapSceneKey, true);
            }
            return EditorPrefs.GetBool(k_LoadBootstrapSceneKey, true);
        }
        set => EditorPrefs.SetBool(k_LoadBootstrapSceneKey, value);
    }
    static bool isStartServer
    {
        get
        {
            if (!EditorPrefs.HasKey(k_StartState))
            {
                EditorPrefs.SetBool(k_StartState, true);
            }
            return EditorPrefs.GetBool(k_StartState, true);
        }
        set => EditorPrefs.SetBool(k_StartState, value);
    }
    #endregion

    #region MENU ITEM

    [MenuItem(netStartServer)]
    static void StartServer()
    {
    }

    [MenuItem(netStartServer)]
    static bool ShowStartServer()
    {
        return !isStartServer;
    }

    [MenuItem(netStartClient)]
    static void StartClient()
    {
        
    }
    [MenuItem(netStartClient)]
    static bool ShowStartClient()
    {
        return !isStartServer;
    }

    #endregion

    #region Start client / server && bootstrap scene

    static void EditorApplicationOnplayModeStateChanged(PlayModeStateChange obj)
    {
        if (!LoadBootstrapScene) return;

        if (obj == PlayModeStateChange.ExitingEditMode)
        {
            //Caching scene now
            PreviousScene = EditorSceneManager.GetActiveScene().path;
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                if (!string.IsNullOrEmpty(BootstrapScene)
                    && System.Array.Exists(EditorBuildSettings.scenes, scene => scene.path == BootstrapScene))
                {
                    EditorSceneManager.OpenScene(BootstrapScene);
                }
            }
            else
            {
                EditorApplication.isPlaying = false;
            }
        } else if (obj == PlayModeStateChange.EnteredEditMode)
        {
            if (!string.IsNullOrEmpty(PreviousScene))
            {
                EditorSceneManager.OpenScene(PreviousScene);
            }
        } else if (obj == PlayModeStateChange.EnteredPlayMode)
        {
            if (isStartServer)
            {
                
            }
        }
    }


    #endregion
}