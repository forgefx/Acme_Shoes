﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace BuildScripts
{
    /// <summary>
    /// Example call from TeamCity Build step:
    /// BuildScripts.BuildHelper.BuildSolution_Acme_Shoes
    /// </summary>
    public static class BuildHelper
    {
        public static void SelfTest()
        {
            BuildScripts.BuildHelper.BuildSolution_Acme_Shoes();
        }

        public static void BuildSolution_Acme_Shoes()
        {
            Build();
        }

        [MenuItem("BuildTests/BuildHelper.Build()")]
        public static void Build()
        {
            

            // Application version.
            string appVersion = Application.version; // Example: "2022.7.21.1940"
            string productName = Application.productName; // Example: "Acme Shoes HoloTrainer"

            var productCode = ProductCode(productName);
            Debug.Log($"Product code: {productCode}");

            //
            var path = $@"../Builds/{appVersion}/{productCode}/Temp";
            Debug.Log($"Path: {path}");

            // Build solution.
            EditorUserBuildSettings.wsaSubtarget = WSASubtarget.HoloLens;
            EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;


            EditorUserBuildSettings.wsaUWPVisualStudioVersion = GetVisualStudioBuildVersion();//"16.11.32802.440";

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
            buildPlayerOptions.locationPathName = "../Build-Zebra"; // was: path; 
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

        private static string GetVisualStudioBuildVersion()
        {
            string ret = "";

            var args = Environment.GetCommandLineArgs();
            if (args.Length < 0 || !args.Contains("-VisualStudioBuildVersion"))
                return ret;

            string pattern = @"^([0-9]+.){5}$";

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-VisualStudioBuildVersion")
                {
                    Debug.Log(args[i]);
                    Debug.Log(args[i + 1]);

                    if (Regex.IsMatch(args[i + 1], pattern))
                        ret = args[i + 1];

                    break;
                }
            }

            return ret;
        }
    }
}
