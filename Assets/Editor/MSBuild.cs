using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;


public class MSBuild : EditorWindow
{
    public static string
        TargetFolder =
            @"C:\Repos\HoloLens-SpinningCube\Builds-fromEditorBuildScript";


    [MenuItem("Build_VSPROJ/HoloLens APPX Build_VSPROJ Window")]
    public static void ShowWindow()
    {
        var window = EditorWindow.GetWindow(typeof(MSBuild));
        var titleContent = new GUIContent();
        titleContent.text = "Build_VSPROJ and Publish";
        window.titleContent = titleContent;
    }

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
    private void Run_MSBuild()
    {
        // Program to run.
        var program = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild.exe";

        // Command line arguments.
        var arguments = new List<string>();
        arguments.Add("-version");

        // Engage!
        StartProcess(program, arguments);
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
        string txt = "Use this window to build both Visual Studio project files and then .appx files for HoloLens.";
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

        if (GUILayout.Button("Test: MSBuild.exe -version"))
        {
            Run_MSBuild();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="program"></param>
    /// <param name="arguments"></param>
    private void StartProcess(string program, List<string> arguments)
    {
        // Process setup.
        Process process = new Process();
        process.StartInfo.FileName = program;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        // Process arguments.
        var argumentsString = String.Empty;
        foreach (var argument in arguments)
        {
            argumentsString = argumentsString + argument + " ";
        }
        process.StartInfo.Arguments = argumentsString;

        // Pipe process output to unity console.
        process.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            Debug.Log(e.Data);
        });
        process.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            Debug.Log(e.Data);
        });

        // Engage!
        process.Start();

        // Also, grab that output from the process.
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        //
        Debug.Log($"StartProcess( process:{program}, arguments:{argumentsString})");
    }

    private void StartProcessWithOutput()
    {
        Process p = new Process();
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild.exe";
        p.StartInfo.Arguments = "-version";

        p.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            //Console.WriteLine(e.Data);
            Debug.Log(e.Data);
        });
        p.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            //Console.WriteLine(e.Data);
            Debug.Log(e.Data);
        });

        p.Start();
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
    }

    public void OpenFolder()
    {
        Application.OpenURL(TargetFolder);
    }

    public enum LineSpace
    {
        Small = 10,
        Medium = 20,
        Large = 30
    }

    /// <summary>
    /// Example usage of StartProcess() method, including arguments list.
    /// </summary>
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
