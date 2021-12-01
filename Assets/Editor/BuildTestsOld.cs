using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;



public class BuildTestsOld : EditorWindow
{
    public static string
        TargetFolder =
            @"C:\Repos\HoloLens-SpinningCube\Builds-fromEditorBuildScript";


    [MenuItem("BuildTests/Show Window")]
    public static void ShowWindow()
    {
        var window = EditorWindow.GetWindow(typeof(BuildTests));
        var titleContent = new GUIContent();
        titleContent.text = "Build Tests";
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
    /// MSBuild "{Project}.csproj" /p:Configuration=Debug;AppxBundle=Always;AppxBundlePlatforms="x64";OutputPath="AppxPackages"
    /// </summary>
    private void Run_MSBuild()
    {
        // Program to run.
        var program = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild.exe";

        // Command line arguments.
        var arguments = new List<string>();
        //arguments.Add(@"C:\Repos\HoloLens-SpinningCube\Builds-fromEditorBuildScript\HoloLens-SpinningCube\HoloLens-SpinningCube.vcxproj");
        //arguments.Add("/p:configuration="Release"");
        arguments.Add("-version");
        //arguments.Add("/target:restore");
        //arguments.Add("/target:Clean"); // /target:Clean;Rebuild;Publish
        //arguments.Add("/");
        //arguments.Add("-detailedSummary");
        //arguments.Add("-nologo"); // Don't display the startup banner or the copyright message.
        //arguments.Add("-restore"); // Runs the Restore target prior to building the actual targets.
        //arguments.Add("-target:targets-go-here"); // Build the specified targets in the project.
        //arguments.Add("-targets[:file]"); // Write the list of available targets to the specified file (or the output device, if no file is specified), without actually executing the build process.


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

    private string _output;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="program"></param>
    /// <param name="arguments"></param>
    private void StartProcess(string program, List<string> arguments)
    {
        _output = String.Empty;

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
            if (argument != String.Empty)
            {
                argumentsString = argumentsString + argument + " ";
            }
        }
        process.StartInfo.Arguments = argumentsString;

        // Pipe process output to unity console.
        process.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            if (e.Data.Length > 0)
            {
                Debug.Log($"e.Data: {e.Data}");
                //_output += e.Data + Environment.NewLine;
            }
        });
        process.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            if (e.Data.Length > 0)
            {
                Debug.Log($"e.Data: {e.Data}");
                //_output += e.Data + Environment.NewLine;
            }
        });

        // Engage!
        process.Start();

        // Also, grab that output from the process.
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        //
        Debug.Log($"StartProcess( process:{program}, arguments:{argumentsString})");

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
