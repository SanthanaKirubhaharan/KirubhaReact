using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public static class Program
{
    public static void Main()
    {
        LibraryRunner.RunLibraryCodeFromFile("C:\\Temp\\code.txt");
    }
}


public static class LibraryRunner
{
    public static void RunLibraryCodeFromFile(string filePath)
    {
        string code = File.ReadAllText(filePath);

        // Set up the compilation options
        var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

        // Add necessary references
        var references = new[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location)
        };

        // Compile the code
        var syntaxTree = SyntaxFactory.ParseSyntaxTree(code);
        var compilation = CSharpCompilation.Create("LibraryAssembly")
            .WithOptions(compilationOptions)
            .AddReferences(references)
            .AddSyntaxTrees(syntaxTree);

        using var ms = new MemoryStream();
        var emitResult = compilation.Emit(ms);

        if (!emitResult.Success)
        {
            // Handle compilation errors
            foreach (var diagnostic in emitResult.Diagnostics)
            {
                Console.WriteLine(diagnostic.ToString());
            }
        }
        else
        {
            ms.Seek(0, SeekOrigin.Begin);

            // Load the compiled assembly
            var assembly = Assembly.Load(ms.ToArray());

            // Execute the library code
            var libraryClassType = assembly.GetType("LibClass");
            var libraryInstance = Activator.CreateInstance(libraryClassType);

            var libraryMethod = libraryClassType.GetMethod("LibMethod");
            libraryMethod.Invoke(libraryInstance, null);
        }
    }
}

