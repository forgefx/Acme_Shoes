using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;

public static class SolutionBuilder
{
    public static void Build()
    {
        {
            // Build solution.
            EditorUserBuildSettings.wsaSubtarget = WSASubtarget.HoloLens;
            EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"};
            buildPlayerOptions.locationPathName = "Starfish"; // was: @"C:/Builds";
            buildPlayerOptions.target = BuildTarget.WSAPlayer;
            buildPlayerOptions.options = BuildOptions.None;
            BuildPipeline.BuildPlayer(buildPlayerOptions);

            // Build .appx
            MSBuild.ConfigureAndRun();
        }
    }
}
