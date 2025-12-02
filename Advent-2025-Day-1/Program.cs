Console.WriteLine("Advent Of Code 2025");
Console.WriteLine("--- Day 1: Secret Entrance ---");

// Input file paths
var inputPath = "PuzzleInput.txt";
var testPath = "testInput.txt";
var bigTestPath = "bigRotationTest.txt"; 

// Initial dial position
var dialPosition = 50;

Console.WriteLine($"Initial Dial Position = {dialPosition}");

try
{
    var rotations = File.ReadLines(inputPath);

    var pass = Advent_2025_Day_1.Decoder.Decode(dialPosition, rotations);

    Console.WriteLine($"Password = {pass}");
}
catch (IOException e)
{
    Console.WriteLine($"An I/O error occurred: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"An unexpected error occurred: {e.Message}");
}
