using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;
using BuildScripts;

public static class SolutionBuilder
{
    [MenuItem("BuildTests/SolutionBuilder.Build()")]
    public static void Build()
    {
        {
            var foo = BuildScripts.BuildAgentInfo.GetInfo();
            var bar = BuildAgentInfo.TryGetPathToUWPEditorExtensions();
            
            // Build solution.
            EditorUserBuildSettings.wsaSubtarget = WSASubtarget.HoloLens;
            EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"};
            buildPlayerOptions.locationPathName = @"../Build-SLN2"; // was: @"C:/Builds";
            buildPlayerOptions.target = BuildTarget.WSAPlayer;
            buildPlayerOptions.options = BuildOptions.None; // BuildOptions.AutoRunPlayer; // In theory, this causes .appx to be generated.
            //buildPlayerOptions.targetGroup = BuildTargetGroup.WSA;
            
            Debug.Log("[FFX] BuildPipeline.BuildPlayer(buildPlayerOptions);");
            BuildPipeline.BuildPlayer(buildPlayerOptions);

            // Build .appx
            //MSBuild.ConfigureAndRun();
        }
    }

}
