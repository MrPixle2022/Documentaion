# FileIo:

to interact with the file system .net provides some useful types like:

-   `DirectoryInfo`
-   `Directory`
-   `File`
-   `FileInfo`
-   `Path`

the `XInfo` vs `X` difference is that the `DirectoryInfo` -for example- is an insatiable object that can be used for multiple operations while the `Directory` -for example- is for single use as it uses static methods.

---

## DirectoryInfo:

the `DirectoryInfo` class is used to create objects that reference directories.

the constructor takes a `string path` to the directory -even if it doesn't exist- and gives you access the full path and some other information.

```csharp
DirectoryInfo amrDir = new(@"C:\Users\Amro\Desktop\Amr\Programming");

System.Console.WriteLine(amrDir.Name); //Programming
System.Console.WriteLine(amrDir.FullName); //C:\Users\Amro\Desktop\Amr\Programming
System.Console.WriteLine(amrDir.Parent); //C:\Users\Amro\Desktop\Amr\
System.Console.WriteLine(amrDir.GetDirectories().Count()); //how many directories contained
System.Console.WriteLine(amrDir.GetFiles().Count()); //how many files contained

DirectoryInfo directoryInfo = new(@"C:\Users\Amro\Desktop\Amr\Programming\myC");
directoryInfo.Create();
// Directory.CreateDirectory(string path) //also works
directoryInfo.Delete();
// Directory.Delete(string path); //also works
```

---

## FileInfo:

the `FileInfo` class is used to create objects that reference files even if the file is yet to exist.

you have access to the file's attributes and extension + other information.

```csharp
FileInfo[] filesInfo = new DirectoryInfo(
    @"C:\Users\Amro\Desktop\Amr\Programming"
).GetFiles();

foreach (FileInfo file in filesInfo)
{
    System.Console.WriteLine("{0} : {1}", file.Name, file.Extension);
    file.Create();
    file.Delete();
}

```

---

## File:

the `File` class is useful to interact with files in you file system.

```csharp
string textFilePath = @"C:\Users\Amro\Desktop\Amr\Programming\myC.text";
File.WriteAllLines(textFilePath, new[] { "Hello", "World" });

foreach (string line in File.ReadAllLines(textFilePath))
    System.Console.WriteLine(line);

FileInfo fileInfo = new(textFilePath);
System.Console.WriteLine(fileInfo.Extension); //.text
System.Console.WriteLine(fileInfo.Name); //myC
System.Console.WriteLine(fileInfo.FullName); //C:\Users\Amro\Desktop\Amr\Programming\myC.text
System.Console.WriteLine(fileInfo.Length); //14
```
