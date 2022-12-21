// See https://aka.ms/new-console-template for more information

using Day4;

bool DoesOneRangeOverlapWithAnother(string input)
{
    var range1 = input.Split(",")[0];
    var range2 = input.Split(",")[1];
    
    var range1Lower = int.Parse(range1.Split("-")[0]);
    var range1Upper = int.Parse(range1.Split("-")[1]);
    var range2Lower = int.Parse(range2.Split("-")[0]);
    var range2Upper = int.Parse(range2.Split("-")[1]);

    List<int> range1List = new List<int>();
    List<int> range2List = new List<int>();

    for (int i = range1Lower; i <= range1Upper; i++)
    {
        range1List.Add(i);
    }
    for (int i = range2Lower; i <= range2Upper; i++)
    {
        range2List.Add(i);
    }

    return range1List.Intersect(range2List).Any();
}

var containingRanges = Input.InputString.Split("\r\n")
    .Where(DoesOneRangeOverlapWithAnother)
    .Count();
    
Console.WriteLine(containingRanges);