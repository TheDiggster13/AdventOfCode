// See https://aka.ms/new-console-template for more information

using Day3;

int GetPriorityForItem(char item)
{
    var absoluteChar = Char.ToLower(item);
    var baseValue = absoluteChar - 96;
    if (Char.IsUpper(item))
    {
        return baseValue + 26;
    }

    return baseValue;
}

Tuple<string, string> SplitRucksack(string rucksack)
{
    var firstHalf = rucksack.Substring(0, rucksack.Length / 2);
    var secondHalf = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);
    return new Tuple<string, string>(firstHalf, secondHalf);
}

char GetCommonItem(List<string> rucksacks)
{
    HashSet<char> firstRucksack = new HashSet<char>(rucksacks.SelectMany(x => x.ToCharArray()));
    foreach (var rucksack in rucksacks.Skip(1))
    {
        firstRucksack.IntersectWith(rucksack);
    }
    return firstRucksack.First();
}

char GetMisplacedItem(Tuple<string, string> rucksack)
{
    return rucksack.Item1.Intersect(rucksack.Item2).First();
}

var misplacedPriorities = Input.InputString
    .Split("\r\n")
    .Select((x, idx) => new { idx, x})
    .GroupBy(x => x.idx / 3)
    .ToDictionary(x => x.Key, x => x.Select(y => y.x).ToList())
    .Select(x =>
    {
        var commonItem = GetCommonItem(x.Value);
        return GetPriorityForItem(commonItem);
    })
    .Sum();
    
Console.WriteLine(misplacedPriorities);