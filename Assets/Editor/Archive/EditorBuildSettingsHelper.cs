using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using Debug = UnityEngine.Debug;

public class EditorBuildSettingsHelper
{
    public static bool DebugEnabled = false;

    /// <summary>
    /// Returns list of scenes in current editor build scene list dialog.
    /// This list is returned as a list of string path names to the scenes.
    /// Example usage: BuildPlayerOptions.scenes = EditorBuildSettingsHelper.GetScenesList()
    /// </summary>
    [MenuItem("Build/EditorBuildSettingsHelper.GetScenesList()")]
    public static string[] GetScenesList()
    {
        List<string> scenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                var scenePath = scene.path;
                scenes.Add(scenePath);
            }
        }

        if (DebugEnabled)
        {
            foreach (var scene in scenes)
            {
                Debug.Log($"[EditorBuildSettingsHelper] GetScenesList(): Found scene: {scene} ");
            }
            Debug.Log($"[EditorBuildSettingsHelper] GetScenesList(): Found {scenes.Count} scene(s).");
        }

        //
        return scenes.ToArray();
    }
}
