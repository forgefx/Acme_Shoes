using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class SolutionBuilder
{
    [MenuItem("BuildTests/SolutionBuilder.Build()")]
    public static void Build()
    {
        // Application version.
        string appVersion = Application.version;           // Example: "2022.7.21.1940"
        string productName = Application.productName;      // Example: "Acme Shoes HoloTrainer"
        
        var productCode = ProductCode(productName);
        Debug.Log($"Product code: {productCode}");
        
        //
        var path = $@"../Temp"; // was:  $@"../Builds/{appVersion}/{productCode}/Temp"; 
        Debug.Log($"Path: {path}");
        
        // Build solution.
        EditorUserBuildSettings.wsaSubtarget = WSASubtarget.HoloLens;
        EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = path; 
        buildPlayerOptions.target = BuildTarget.WSAPlayer;
        buildPlayerOptions.options = BuildOptions.None; // BuildOptions.AutoRunPlayer; // In theory, this causes .appx to be generated.
        //buildPlayerOptions.targetGroup = BuildTargetGroup.WSA;

        Debug.Log("[FFX] BuildPipeline.BuildPlayer(buildPlayerOptions);");
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        // Build .appx
        //MSBuild.ConfigureAndRun();
    }

    private static string ProductCode(string productName)
    {
        // Remove " HoloTrainer"
        string productCode = productName.Replace(" HoloTrainer", "");

        // Replace any spaces with underscores.
        productCode = productCode.Replace(" ", "_");

        // Replace any dashes with underscores.
        productCode = productCode.Replace("-", "_");
        
        return productCode;
    }
}
