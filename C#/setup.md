<!-- @format -->

# Setup

use the command:

```bash
dotnet new console
```

or use the dotnet dev kit in vs code or the create project in visual studio code.

in the end you will have yourself:

```csharp
Console.WriteLine("Hello World");
```

unlike the old versions where you had to have:

```csharp
using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("hello, this is a new Project");
  }
}
```

---

## Assembly

the `Assembly` contains all types, configurations and IL code

the process of compiling our application goes as follow:

source code => Dotnet compiler => IL (intermediate language, on .NET platform) code => CLR (Common Language Runtime, runs the IL code) => Machine Code

inside the `/bin/Debug/net[version]` folder we have the assemblies

- DLL (Dynamic Link Library) => used by different projects (the assemblies that contain code to be used by other applications)
- EXE (Executable) => Applications (changes depending on the operating system)

when we compile the project the source code is turned into:

- IL code (translated into machine code by the .NET CLR)
- the assembly (info about info -the sourcecode-) in both `.exe` (process assemblies) or `.dll` (library assemblies)

the `.exe` has a main method that can run on it's own while the `.dll` has no entry point and is called from another app.

the assembly is platform independent (can run on any OS that has the .NET runtime installed)

the IL is executed by the JIT (Just In Time) compiler of the CLR, which converts the IL code into machine code specific to the OS and hardware.

we can get the assembly from the IL code and vice versa using `ILDASM` and `ILASM`

- ILDASM => converts the .dll to IL code (disassembler)
- ILASM => converts the IL code back to .dll (assembler)

an assemble contains:

- Manifest: like an ID for that specific assembly (metadata about the assembly - version, culture, name, list of files, types, resources)
- Type Metadata (info about types defined in the assembly - classes, interfaces, structs, enums)
- IL Code (the actual code in Intermediate Language)
- Resources (non-code assets like images, strings, etc. that are embedded in the assembly)

we can find what assembly a class belongs to by using the `typeof(ClassName).Assembly.FullName` property.

also we can use the `Assembly.GetExecutingAssembly()` method from the `System.Reflection` namespace to load and inspect assemblies at runtime.

```csharp
ar assembly = Assembly.GetExecutingAssembly();

var fullname = assembly.FullName; // the assembly's full name
var location = assembly.Location; // the assembly's location on disk

var aName = assembly.GetName(); // gets an AssemblyName object that contains the assembly's name, version, culture, and public key
var name = aName.Name; // the assembly's simple name
var version = aName.Version; // the assembly's version

//can use dllname.pathtofile.extension
using(var stream = assembly.GetManifestResourceStream("MyNamespace.MyResource.txt"))
{
 // gets a resource stream from the assembly
var data = new BinaryReader(stream!).ReadBytes((int)stream!.Length);
};
```

multiple assemblies can communicate with each other through references.

---

## .NET cli

the `dotnet` command allows us to create, build and install packages and much much more from the `terminal`

```bash
# --- basic ---
# create a new project
dotnet new <project-type> -o <output_dir>
# build a project
dotnet build -o <output_dir>
# run the project
dotnet run
# hot reload
dotnet watch
# --- solution ---
# new empty solution
dotnet new sln
# adds a project to the solution
dotnet sln add <path_to_project>
# adds a reference to another project so it's usable in this one
dotnet add reference <path_to_project>
# --- packages and Nuget ---
# import a new package
dotnet add package <package>
# list used packages in the project
dotnet list package
# re-installs and verifies the packages installed
dotnet restore
# --- advanced ---
# given the project -locally- an HTTPS certificate
dotnet dev-certs https --trust
```
