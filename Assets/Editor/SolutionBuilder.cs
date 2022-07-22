using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class SolutionBuilder
{
    [MenuItem("BuildTests/SolutionBuilder.Build()")]
    public static void Build()
    {
        // Application version.
        string appVersion = Application.version;
        string productName = Application.productName;
        
        // Create productCode by replacing spaces and dashes with underscores in product name.
        string productCode = productName.Replace(" ", "_").Replace("-", "_");
        
        // Build solution.
        EditorUserBuildSettings.wsaSubtarget = WSASubtarget.HoloLens;
        EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = $@"../Builds/{appVersion}/{productCode}"; // was: @"C:/Builds";
        buildPlayerOptions.target = BuildTarget.WSAPlayer;
        buildPlayerOptions.options = BuildOptions.None; // BuildOptions.AutoRunPlayer; // In theory, this causes .appx to be generated.
        //buildPlayerOptions.targetGroup = BuildTargetGroup.WSA;

        Debug.Log("[FFX] BuildPipeline.BuildPlayer(buildPlayerOptions);");
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        // Build .appx
        //MSBuild.ConfigureAndRun();
    }
}
