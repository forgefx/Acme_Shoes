using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;


namespace _Dashboard
{
    public class MSBuild : EditorWindow
    {
        public static string
            TargetFolder =
                @"C:\Repos\HoloLens-SpinningCube\Builds-fromEditorBuildScript";

        /// <summary>
        /// Build Visual Studio project.
        /// </summary>
        public void Build_VSPROJ()
        {
            EditorUserBuildSettings.wsaSubtarget = WSASubtarget.HoloLens;
            EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.D3D;

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
            buildPlayerOptions.locationPathName = "Builds-fromEditorBuildScript";
            buildPlayerOptions.target = BuildTarget.WSAPlayer;
            buildPlayerOptions.options = BuildOptions.None;
            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }

        /// <summary>
        /// Build .appx file for HoloLens.
        /// </summary>
        private void Build_APPX()
        {
            // Program to run.
            var program = @"C:\Program Files (x86)\Notepad++\notepad++.exe";

            // Command line arguments.
            var arguments = new List<string>();
            arguments.Add("-loadingTime");
            arguments.Add("--help");

            // Engage!
            StartProcess(program, arguments);
        }

















        bool groupEnabled;

 

        public static string DashboardURL = "https://forgeboards.com/cbrnd-ar/";

        [MenuItem("Build_VSPROJ/HoloLens APPX Build_VSPROJ Window")]
        public static void ShowWindow()
        {
            var window = EditorWindow.GetWindow(typeof(MSBuild));
            var titleContent = new GUIContent();
            titleContent.text = "Build_VSPROJ and Publish";
            window.titleContent = titleContent;
        }

        private void OnGUI()
        {
            GUILayout.Space((int)LineSpace.Small);

            EditorStyles.label.wordWrap = true;

            var leftMargin = new RectOffset(2, 0, 0, 0);

            EditorStyles.textField.margin = leftMargin;
            EditorStyles.label.margin = leftMargin;
            EditorStyles.toggleGroup.margin = leftMargin;

            // INTRO TEXT
            GUILayout.Space((int)LineSpace.Small);
            string txt = "Use this window to build and publish WebGL up to the FTP server.";
            GUILayout.Label(txt, EditorStyles.wordWrappedLabel);
            GUILayout.Space((int)LineSpace.Small);

            // Spacer
            GUILayout.Space((int)LineSpace.Medium);


            // SOURCE FOLDER
            GUILayout.Label("BUILD PROJECT FILES", EditorStyles.boldLabel);
            GUILayout.Label("--------------------------------------------------", EditorStyles.boldLabel);
            GUILayout.Space((int)LineSpace.Small);

            TargetFolder = EditorGUILayout.TextField("Build_VSPROJ folder", TargetFolder);
            GUILayout.Space((int)LineSpace.Small);

            if (GUILayout.Button("Build_VSPROJ"))
            {
                Build_VSPROJ();
            }

            if (GUILayout.Button("Open Folder"))
            {
                OpenFolder();
            }

            // Spacer
            GUILayout.Space((int)LineSpace.Large);

            // FTP INFO
            GUILayout.Label("BUILD APPX FILE", EditorStyles.boldLabel);
            GUILayout.Label("--------------------------------------------------", EditorStyles.boldLabel);
            GUILayout.Space((int)LineSpace.Small);

            GUILayout.Space((int)LineSpace.Small);

            if (GUILayout.Button("Build_VSPROJ .appx 5"))
            {
                Build_APPX();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="arguments"></param>
        private void StartProcess(string program, List<string> arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = program;
            var argumentsString = String.Empty;
            foreach (var argument in arguments)
            {
                argumentsString = argumentsString + argument + " ";
            }

            process.StartInfo.Arguments = argumentsString;
            process.Start();

            Debug.Log($"StartProcess( process:{program}, arguments:{argumentsString})");
        }


        public void Test()
        {
            Debug.Log("Test");
        }

        public void OpenFolder()
        {
            Application.OpenURL(TargetFolder);
        }

        public void OpenWebpage()
        {
            Application.OpenURL(DashboardURL);
        }

        public enum LineSpace
        {
            Small = 10,
            Medium = 20,
            Large = 30
        }

        private void StartNotepad()
        {
            // Program to run.
            var program = @"C:\Program Files (x86)\Notepad++\notepad++.exe";

            // Command line arguments.
            var arguments = new List<string>();
            arguments.Add("-loadingTime");
            arguments.Add("--help");

            // Engage!
            StartProcess(program, arguments);
        }
    }
}
