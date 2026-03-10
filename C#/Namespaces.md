# Namespace

a namespace is used to organize project classes and interfaces.

define an interface using the `namespace` keyword

```csharp
namespace App.Main;
```

and we can import a namespace using the `using` keyword:

```csharp
using System.Collection;
```

note we also can make aliases for namespaces

```csharp
using Main = App.Source.Main;

namespace Main;
```
