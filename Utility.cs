using System;
using System.IO;

namespace YMAL_to_JSON_converter
{
    public static class Utility
    {
        public static string GetOutputFilePath(string fileName, string directoryPath, ConversionTarget conversionTarget) =>
            conversionTarget switch
            {
                ConversionTarget.ToJson => Path.Combine(directoryPath, $"{fileName}.json"),
                ConversionTarget.ToYaml => Path.Combine(directoryPath, $"{fileName}.yaml"),
                _ => throw new ArgumentOutOfRangeException(nameof(conversionTarget),
                    $"Not expected conversion target: {conversionTarget}")
            };
    }
}