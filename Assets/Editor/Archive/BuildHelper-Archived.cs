// using System;
// using System.Diagnostics;
// using UnityEditor;
// using UnityEngine;
// using Debug = UnityEngine.Debug;
// using System.Collections.Generic;
//
// namespace BuildScripts
// {
//     /// <summary>
//     /// Build scripts for both local and server-side use.
//     /// Example: on build server (i.e. TeamCity)
//     /// </summary>
//     public static class BuildHelper
//     {
//         public static bool DebugEnabled = true;
//
//         /// <summary>
//         /// In the context of our HoloLens project, this builds the Visual Studio
//         /// project output. This can then be used in subsequent build steps to
//         /// produce the .appx executable required by the HoloLens.
//         /// </summary>
//         //[MenuItem("Build/BuildHelper.BuildSolution()")]
//         public static void BuildSolution()
//         {
//             {
//                 Debug.Log("BuildScriptsBuildHelper.BuildSolution() - Begin");
//
//                 // EditorUserBuildSettings
//                 
//                 EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.WSAPlayer);
//                 EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;
//                 EditorUserBuildSettings.wsaSubtarget = WSASubtarget.HoloLens;
//                 EditorUserBuildSettings.enableHeadlessMode = true;
//
//                 // BuildPlayerOptions
//                 BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
//                 EditorBuildSettingsHelper.DebugEnabled = true;
//                 buildPlayerOptions.scenes = EditorBuildSettingsHelper.GetScenesList();
//                 buildPlayerOptions.locationPathName = "Build-SLN";  // TO DO:  Change to @"Build/SLN"
//                 buildPlayerOptions.targetGroup = BuildTargetGroup.WSA; // Note:  Optional? -AK 1/16/2022
//                 buildPlayerOptions.target = BuildTarget.WSAPlayer;
//                 buildPlayerOptions.options = BuildOptions.EnableHeadlessMode;
//                 
//
//                 if (DebugEnabled)
//                 {
//                     DisplayDebugInfo(buildPlayerOptions);
//                     BuildAgentInfo.GetInfo();
//                     BuildAgentInfo.TryGetPathToUWPEditorExtensions();
//                 }
//
//                 // Start the build.
//                 //BuildPipeline.BuildPlayer(buildPlayerOptions);
//
//                 Debug.Log("BuildScriptsBuildHelper.BuildSolution() - End");
//             }
//         }
//
//         private static void DisplayDebugInfo(BuildPlayerOptions buildPlayerOptions)
//         {
//             var NL = Environment.NewLine;
//             var info = $"{NL}{NL}";
//             
//             info += $"============== FORGEFX BUILD INFO (START) ============== {NL}{NL}";
//
//             info += $"EditorUserBuildSettings.wsaUWPSDK = {EditorUserBuildSettings.wsaUWPSDK}{NL}";
//             info += $"EditorUserBuildSettings.wsaArchitecture = {EditorUserBuildSettings.wsaArchitecture}{NL}";
//             info += $"EditorUserBuildSettings.selectedStandaloneTarget = {EditorUserBuildSettings.selectedStandaloneTarget}{NL}";
//             info += $"EditorUserBuildSettings.selectedBuildTargetGroup = {EditorUserBuildSettings.selectedBuildTargetGroup}{NL}";
//             info += $"EditorUserBuildSettings.enableHeadlessMode = {EditorUserBuildSettings.enableHeadlessMode}{NL}";
//             info += $"EditorUserBuildSettings.activeBuildTarget = {EditorUserBuildSettings.activeBuildTarget}{NL}";
//             info += $"EditorUserBuildSettings.wsaSubtarget = {EditorUserBuildSettings.wsaSubtarget}{NL}";
//             info += $"EditorUserBuildSettings.wsaUWPBuildType = {EditorUserBuildSettings.wsaUWPBuildType}{NL}";
//             info += $"buildPlayerOptions.scenes.Length = {buildPlayerOptions.scenes.Length}{NL}";
//             info += $"buildPlayerOptions.locationPathName = {buildPlayerOptions.locationPathName}{NL}";
//             info += $"buildPlayerOptions.target = {buildPlayerOptions.target}{NL}";
//             info += $"buildPlayerOptions.options = {buildPlayerOptions.options}{NL}";
//             info += $"buildPlayerOptions.targetGroup = {buildPlayerOptions.targetGroup}{NL}";
//             info += $"{NL}";
//             info += $"============== FORGEFX BUILD INFO (END) ============== {NL}{NL}";
//
//             Debug.Log(info);
//         }
//
//     }
// }
