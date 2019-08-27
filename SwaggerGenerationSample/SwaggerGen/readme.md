We use the files in this directory to generate `swagger.json` during build time.

`dotnet-swagger.dll` is a custom built version which includes a patch for cases when the input assemblies to the Swagger CLI tool have embedded spaces. A pull request was sent to the official Swagger GitHub repo (https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/1032) but after this is accepted no new stable version is pushed.

If a newer version is required to be built and the PR above has not been merged, consider applying the patch below (as taken from the PR):

Edit `src/Swashbuckle.AspNetCore.Cli/Program.cs` and surround the `typeof(Program).GetTypeInfo().Assembly.Location` parameter with a call to `EscapePath()`. After building the solution, one can find `dotnet-swagger.dll` is in the output build folder of the `Swashbuckle.AspNetCore.Cli` project.

Before:

``` csharp
var subProcess = Process.Start("dotnet", string.Format(
    "exec --depsfile {0} --runtimeconfig {1} {2} _{3}", // note the underscore
    EscapePath(depsFile),
    EscapePath(runtimeConfig),
    typeof(Program).GetTypeInfo().Assembly.Location,
    string.Join(" ", args)));
```

After:

``` csharp
var subProcess = Process.Start("dotnet", string.Format(
    "exec --depsfile {0} --runtimeconfig {1} {2} _{3}", // note the underscore
    EscapePath(depsFile),
    EscapePath(runtimeConfig),
    EscapePath(typeof(Program).GetTypeInfo().Assembly.Location),
    string.Join(" ", args)));
```
