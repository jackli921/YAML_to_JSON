using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace YMAL_to_JSON_converter
{
    internal class Program
    {
        static internal bool isValidFilePath { get; set; } = false;
        static internal string filePath { get; set; }

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What would you like to do");
                Console.WriteLine("1. Convert YAML to JSON");
                Console.WriteLine("2. Convert JSON to YAML");
                Console.WriteLine("3. Exit");
                
                if (Enum.TryParse(Console.ReadLine(), out MenuChoice choice))
                {
                    switch (choice)
                    {
                        case MenuChoice.ConvertYamlToJson:
                            HandleConversion(1);
                            break;
                        case MenuChoice.ConvertJsonToYaml:
                            HandleConversion(2);
                            break;
                        case MenuChoice.Exit:
                            Console.WriteLine("Exiting the program ...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try Again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            
            Console.WriteLine($"filepath you entered is {filePath}");
            string fileContent = File.ReadAllText(filePath);
            string json = SerializeAndDeserialize.SerializeToJson(fileContent);
            Console.WriteLine(json);
            
            var pause = Console.ReadLine();
        }

        public static void HandleConversion(int choice)
        {
            while (true)
            {
                Console.WriteLine("Enter the file path (or enter '0' to go back to the main menu): ");
                string filePath = Console.ReadLine();

                if (filePath == "0")
                {
                    return;
                }
                else if (File.Exists(filePath))
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string directoryPath = Path.GetDirectoryName(filePath);
                    string outputFilepath = Path.Combine(directoryPath, $"{fileName}.json");
                    string inputData = File.ReadAllText(filePath);
                    switch (choice)
                    {
                        case 1:
                            string JsonString = SerializeAndDeserialize.SerializeToJson(inputData);
                            File.WriteAllText(outputFilepath, JsonString);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again");
                            return;
                    }
                        
                    Console.WriteLine("Conversion completed");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid file path. Try again.");
                }
            }
        }

        public static void FormatJsonString(string jsonString)
        {

        }
        
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Address Address { get; set; }
        }

        public struct Address
        {
            public string Street { get; set; }
            public string City { get; set; }
        }
    }
}