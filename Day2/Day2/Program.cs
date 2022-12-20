// See https://aka.ms/new-console-template for more information

using Day2;

var points = new Dictionary<string, int>()
{
    { "Rock", 1 },
    { "Paper", 2 },
    { "Scissors", 3 },
};

var winners = new Dictionary<string, string>()
{
    { "A", "Paper" },
    { "B", "Scissors" },
    { "C", "Rock" },
};

var drawers = new Dictionary<string, string>()
{
    { "A", "Rock" },
    { "B", "Paper" },
    { "C", "Scissors" },
};

var losers = new Dictionary<string, string>()
{
    { "A", "Scissors" },
    { "B", "Rock" },
    { "C", "Paper" },
};

var totalScore = Input.InputString
    .Split("\r\n")
    .Select(CalculateScoreForRound)
    .Sum();

Console.WriteLine(totalScore);

int CalculateScoreForRound(string round, int index)
{
    var player1Choice = round.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
    var player2Strategy = round.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

    int totalScoreForRound = 0;
    
    // Lose
    if (player2Strategy == "X")
    {
        totalScoreForRound += 0;
        var player2Choice = losers[player1Choice];
        totalScoreForRound += points[player2Choice];
    }
    // Tie
    else if (player2Strategy == "Y")
    {
        totalScoreForRound += 3;
        var player2Choice = drawers[player1Choice];
        totalScoreForRound += points[player2Choice];
    }
    else
    {
        totalScoreForRound += 6;
        var player2Choice = winners[player1Choice];
        totalScoreForRound += points[player2Choice];
    }

    return totalScoreForRound;
}