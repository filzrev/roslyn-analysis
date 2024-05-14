using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.MSBuild;
using RoslynAnalysis.Extensions;
using RoslynAnalysis.Model;

namespace RoslynAnalysis
{
    class Program
    {
        static async Task Main()
        {
            var msbuildProperties = new Dictionary<string, string>();
            using var workspace = MSBuildWorkspace.Create(msbuildProperties);
            workspace.WorkspaceFailed += (sender, e) => Console.WriteLine($"{e.Diagnostic}");


            var project = await workspace.OpenProjectAsync(@"./samples/sample.csproj");
        }
    }
}
