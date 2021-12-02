using System;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

class ProcessHelper
{

    private static string _output;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="program"></param>
    /// <param name="arguments"></param>
    public static void StartProcess(string program, List<string> arguments)
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

        //
        Debug.Log($"[Build Output] StartProcess( process:{program}, arguments:{argumentsString})");

        // Engage!
        process.Start();

        // Also, grab that output from the process.
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        // Pipe process output to unity console.
        process.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            if (e.Data.Length > 0)
            {
                Debug.Log($"[Build Output] {e.Data}");
                //_output += e.Data + Environment.NewLine;
            }
        });
        process.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
        {
            if (e.Data.Length > 0)
            {
                Debug.Log($"[Build Output] {e.Data}");
                //_output += e.Data + Environment.NewLine;
            }
        });

    }

}
