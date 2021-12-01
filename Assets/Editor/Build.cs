
using UnityEditor;
using UnityEngine;

public class Build : MonoBehaviour
{
    [MenuItem("Build/UWP")]
    static void UWP()
    {
        EditorUserBuildSettings.wsaSubtarget = WSASubtarget.AnyDevice;
        EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.XAML;

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"};
        buildPlayerOptions.locationPathName = "UWPBuild";
        buildPlayerOptions.target = BuildTarget.WSAPlayer;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
