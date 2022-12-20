// See https://aka.ms/new-console-template for more information

using Day1;

var splitInput = Input.InputString.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
var summedGroups = splitInput
    .SelectMany((x, idx) => 
        x.Split("\r\n")
            .Select(y => new {Elf = idx, Calories = int.Parse(y)}))
    .GroupBy(x => x.Elf)
    .ToDictionary(x => x.Key, x => x.Sum(r => r.Calories))
    .OrderByDescending(x => x.Value);
            
Console.WriteLine(summedGroups.Take(3).Sum(x => x.Value));