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

## Solution

---

## Assembly

the process of compiling our application goes as follow:

source code => Program.cs => Dotnet compiler => IL (intermediate language, on .NET platform) code => CLR (Common Language Runtime, runs the IL code) => Machine Code

inside the `/bin/Debug/net[version]` folder we have the assemblies

- DLL (Dynamic Link Library) => Class Libraries (the assemblies that contain code to be used by other applications)
- EXE (Executable) => Applications (changes depending on the operating system)

when we compile the project the source code is turned into:
  -IL code (pre-machine code)
  -the metadata (info about info -the sourcecode-) is added to create the assembly (DLL or EXE)
  -the assembly is platform independent (can run on any OS that has the .NET runtime installed)
  
  the IL is executed by the JIT (Just In Time) compiler of the CLR, which converts the IL code into machine code specific to the OS and hardware

  ILDASM => converts the .dll to IL code (decompiler)
  ILASM => converts the IL code back to .dll (assembler)

Assemblies contain:

- Manifest (metadata about the assembly - version, culture, string name, list of files, types, resources)
- Type Metadata (info about types defined in the assembly - classes, interfaces, structs, enums)
- MSIL Code (the actual code in Intermediate Language)
- Resources (non-code assets like images, strings, etc. that are embedded in the assembly)

we can find what assembly's name a class belongs to by using the `typeof(ClassName).Assembly.FullName` property
also we can use the `Assembly.GetExecutingAssembly()` method from the `System.Reflection` namespace to load and inspect assemblies at runtime

multiple assemblies can communicate with each other through references.

we can access data on the assembly, for example:

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
