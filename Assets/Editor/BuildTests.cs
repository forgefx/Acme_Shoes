using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;
using BuildScripts;


public class BuildTests : EditorWindow
{



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
        BuildHelper.Build();


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

        // TargetFolder = EditorGUILayout.TextField("Build_VSPROJ folder", TargetFolder);
        // GUILayout.Space((int)LineSpace.Small);

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
            MSBuild.ConfigureAndRun();
        }
    }





    public void OpenFolder()
    {
        //Application.OpenURL(TargetFolder);
    }

    public enum LineSpace
    {
        Small = 10,
        Medium = 20,
        Large = 30
    }

}
