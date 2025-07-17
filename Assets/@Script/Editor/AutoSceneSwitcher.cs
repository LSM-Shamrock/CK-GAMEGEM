#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class AutoSceneSwitcher
{
    static AutoSceneSwitcher()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    static void OnPlayModeChanged(PlayModeStateChange state)
    {
        string StartScenePath = SceneUtility.GetScenePathByBuildIndex(0);
        string PrefsKey = "Exited_Scene_Path";

        if (state == PlayModeStateChange.ExitingEditMode)
        {
            string exitingScenePath = EditorSceneManager.GetActiveScene().path;
            EditorPrefs.SetString(PrefsKey, exitingScenePath);
            if (exitingScenePath != StartScenePath)
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    EditorSceneManager.OpenScene(StartScenePath);
                else
                    EditorApplication.isPlaying = false;
            }
        }
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            string exitedScenePath = EditorPrefs.GetString(PrefsKey);
            EditorSceneManager.OpenScene(exitedScenePath);
        }
    }
}
#endif