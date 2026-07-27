using SwiftlyS2.Shared.SchemaDefinitions;
using System.Reflection;

// Find BeamType_t through all types in the assembly
var asm = typeof(SwiftlyS2.Shared.ISwiftlyCore).Assembly;
foreach (var t in asm.GetExportedTypes().OrderBy(t => t.FullName))
{
    if (t.Name.Contains("Beam"))
    {
        Console.WriteLine($"Type: {t.FullName}, IsEnum: {t.IsEnum}");
        if (t.IsEnum)
            Console.WriteLine($"  Values: {string.Join(", ", Enum.GetNames(t))}");
    }
}
