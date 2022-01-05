using System.Collections.Generic;


public static class MSBuild
{
    /// <summary>
    /// Build .appx file for HoloLens.
    /// MSBuild "{Project}.csproj" /p:Configuration=Debug;AppxBundle=Always;AppxBundlePlatforms="x64";OutputPath="AppxPackages"
    /// </summary>
    public static void ConfigureAndRun()
    {
        // Command line arguments holder.
        var arguments = new List<string>();

        // Program to run.
        var program = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild.exe";

        // What to build.
        arguments.Add(@"C:\Repos\HoloLens-SpinningCube\Build-SLN\HoloLens-SpinningCube.sln");

        // Build configuration.
        arguments.Add("/p:Configuration=Release;AppxBundle=Always;AppxBundlePlatforms=\"ARM64\""); 

        // Engage!
        ProcessHelper.StartProcess(program, arguments);
    }
}


/*

        arguments.Add("/p:AppxPackageDir=\"Builds-Appx-Tiger\"");

        arguments.Add("/p:OutputPath=\"Builds-Appx-Lion\"");

arguments.Add("");
arguments.Add("");
arguments.Add("");
arguments.Add("");
arguments.Add("");
arguments.Add("");
arguments.Add("");
arguments.Add("");
*/

//arguments.Add($"/p:OutputPath={@"C:\Repos\HoloLens-SpinningCube\"}");
//arguments.Add("/p:AppxBundle=Always");

//
//arguments.Add("/p:AppxBundlePlatforms=\"x64\"");

//
// Validate the project file and, if validation succeeds, build the project. If you don't specify schema, the project is validated against the default schema.
//arguments.Add("-validate"); 

//

//arguments.Add("/p:configuration="Release"");
//arguments.Add("-version");
//arguments.Add("/target:restore");
//arguments.Add("/target:Clean"); // /target:Clean;Rebuild;Publish
//arguments.Add("/");
//arguments.Add("-detailedSummary");
//arguments.Add("-nologo"); // Don't display the startup banner or the copyright message.
//arguments.Add("-restore"); // Runs the Restore target prior to building the actual targets.
//arguments.Add("-target:targets-go-here"); // Build the specified targets in the project.
//arguments.Add("-targets[:file]"); // Write the list of available targets to the specified file (or the output device, if no file is specified), without actually executing the build process.

//arguments.Add("/p:OutputPath=Build-01");

//arguments.Add("-p:name=value");
//arguments.Add("-property:name=value");