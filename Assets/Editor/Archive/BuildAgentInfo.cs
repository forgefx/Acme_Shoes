using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace BuildScripts
{
    public static class BuildAgentInfo
    {
        [MenuItem("Build/BuildAgentInfo.TryGetPathToUWPEditorExtensions()")]
        public static string TryGetPathToUWPEditorExtensions()
        {
            
            var NL = Environment.NewLine;
            var info = $"{NL}";
            
            info += $"============== FORGEFX UWP EXTENSIONS INFO (START) ============== {NL}{NL}";
            info += $"{NL}";

            try
            {
                // Get Unity editor path.
                string editorExecutablePath = EditorApplication.applicationPath;
                info += $"editorExecutablePath: {editorExecutablePath}{NL}";
            
                // Get parent folder path of Unity editor.
                string unityEditorDirectory = Directory.GetParent(editorExecutablePath).FullName;
                info += $"unityEditorDirectory: {unityEditorDirectory}{NL}";
            
                // Find "MetroSupport" directory within Unity editor directory.
                string metroSupportDirectory = Directory.GetDirectories(unityEditorDirectory, "MetroSupport", SearchOption.AllDirectories).FirstOrDefault();
                info += $"metroSupportDirectory: {metroSupportDirectory}{NL}";
            
                // Search for "UnityEditor.UWP.Extensions.dll" within "MetroSupport" directory.
                string uwpExtensionsDllPath = Directory.GetFiles(metroSupportDirectory, "UnityEditor.UWP.Extensions.dll", SearchOption.AllDirectories).FirstOrDefault();
                info += $"uwpExtensionsDllPath: {uwpExtensionsDllPath}{NL}";
            }
            catch (Exception e)
            {
                info += $"{NL}";
                info += $"Exception: {e}{NL}";
                info += $"{NL}";
            }

            info += $"{NL}";
            info += $"============== FORGEFX UWP EXTENSIONS INFO (END) ============== {NL}{NL}";
            Debug.Log(info);
            
            return info;
        }

        [MenuItem("Build/BuildAgentInfo.GetInfo()")]
        public static string GetInfo()
        {
            var NL = Environment.NewLine;
            var info = $"{NL}";

            info += $"============== FORGEFX BUILDAGENT INFO (START) ============== {NL}{NL}";

            var a = EditorBuildSettings.GetConfigObjectNames();
            var b = EditorUserBuildSettings.activeBuildTarget; 
            var c = EditorUserBuildSettings.wsaArchitecture;  // Architecture (wasArchitecture): 
            
            info += $"Target Device (wsaSubtarget) = {EditorUserBuildSettings.wsaSubtarget}{NL}";
            info += $"Architecture (wasArchitecture)= {EditorUserBuildSettings.wsaArchitecture}{NL}";
            info += $"Build Type (wsaUWPBuildType) = {EditorUserBuildSettings.wsaUWPBuildType}{NL}";
            info += $"Target SDK Version = {EditorUserBuildSettings.wsaUWPSDK}{NL}";
            info += $"Minimum Platform Version = {EditorUserBuildSettings.wsaMinUWPSDK}{NL}";
            info += $"Visual Studio Version = {EditorUserBuildSettings.wsaUWPVisualStudioVersion}{NL}";
            info += $"Build and Run on = {EditorUserBuildSettings.wsaBuildAndRunDeployTarget}{NL}";
            info += $"Build Configuration = {EditorUserBuildSettings.activeBuildTarget}{NL}";
            info += $"Copy References = ???{NL}";
            info += $"Copy PDB files = ???{NL}";
            info += $"Development Build = {EditorUserBuildSettings.wsaSubtarget}{NL}";
            
            info += $"{NL}";
            info += $"{NL}";
            info += $"{NL}";

            //var platformSettings = EditorUserBuildSettings.GetPlatformSettings(pla)
            
            info += $"{NL}";
            info += $"{NL}";
            info += $"{NL}";
            
            info += $"EditorUserBuildSettings.activeBuildTarget = {EditorUserBuildSettings.activeBuildTarget}{NL}";
            info += $"EditorUserBuildSettings.wsaSubtarget = {EditorUserBuildSettings.wsaSubtarget}{NL}";
            info += $"EditorUserBuildSettings.wsaUWPSDK = {EditorUserBuildSettings.wsaUWPSDK}{NL}";
            info += $"EditorUserBuildSettings.wsaArchitecture = {EditorUserBuildSettings.wsaArchitecture}{NL}";
            info += $"EditorUserBuildSettings.selectedStandaloneTarget = {EditorUserBuildSettings.selectedStandaloneTarget}{NL}";
            info += $"EditorUserBuildSettings.selectedBuildTargetGroup = {EditorUserBuildSettings.selectedBuildTargetGroup}{NL}";
            info += $"EditorUserBuildSettings.enableHeadlessMode = {EditorUserBuildSettings.enableHeadlessMode}{NL}";
            
            info += $"EditorUserBuildSettings.wsaUWPBuildType = {EditorUserBuildSettings.wsaUWPBuildType}{NL}";
            info += $"{NL}";
            info += $"============== FORGEFX BUILDAGENT INFO (END) ============== {NL}{NL}";

            Debug.Log(info);
            return (info);
        }
    }
}
