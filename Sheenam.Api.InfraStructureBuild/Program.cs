//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use ! For Peace 
//==================================================

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using System.Collections.Generic;
using System.IO;

var client = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = "Sheenam Build Pipeline",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Dictionary<string, Job>
    {
        {
            "build",
            new Job
            {
                RunsOn = BuildMachines.Windows2022,

                Steps = new List<GithubTask>
                {
                    new CheckoutTaskV2
                    {
                        Name = "Check out"
                    },

                    new SetupDotNetTaskV1
                    {
                        Name = "Setup .Net",

                        TargetDotNetVersion = new TargetDotNetVersion
                        {
                            DotNetVersion = "8.0.204",
                            IncludePrerelease = true
                        }
                    },

                    new RestoreTask
                    {
                        Name = "Restore"
                    },

                    new DotNetBuildTask
                    {
                        Name = "Build"
                    },

                    new TestTask
                    {
                        Name = "Test"
                    }
                }
            }
        }
    }
};

string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
string absoluteBuildScriptPath = Path.GetFullPath(buildScriptPath);
string directoryPath = Path.GetDirectoryName(absoluteBuildScriptPath);

if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

client.SerializeAndWriteToFile(githubPipeline, path: absoluteBuildScriptPath);