using AoC.Shared;

namespace AoC.Solutions._2023;

public class Day01_2023 : ISolvableDay
{
    public string Part1(IEnumerable<string> input) =>
        BaseSolution(input, TryGetNumericDigit).ToString();

    public string Part2(IEnumerable<string> input) =>
        BaseSolution(input, (string line, int index) => TryGetNumericDigit(line, index) ?? TryGetTextualDigit(line, index)).ToString();

    private int BaseSolution(IEnumerable<string> input, Func<string, int, char?> TryGetDigit) =>
        input.Select((string line) => GetTwoDigitNumber(line, TryGetDigit)).Sum();

    private int GetTwoDigitNumber(string line, Func<string, int, char?> getDigit)
    {
        char? first = null, second = null;
        for (int i = 0; i < line.Length; i++)
        {
            if (getDigit.Invoke(line, i) is char charDigit)
            {
                first ??= charDigit;
                second = charDigit;
            }
        }
        return int.Parse($"{first}{second}");
    }

    private char? TryGetNumericDigit(string line, int index)
    {
        if (char.IsDigit(line[index]))
            return line[index];
        return null;
    }

    private char? TryGetTextualDigit(string line, int index)
    {
        return line[index..] switch
        {
            ['o', 'n', 'e', ..] => '1',
            ['t', 'w', 'o', ..] => '2',
            ['t', 'h', 'r', 'e', 'e', ..] => '3',
            ['f', 'o', 'u', 'r', ..] => '4',
            ['f', 'i', 'v', 'e', ..] => '5',
            ['s', 'i', 'x', ..] => '6',
            ['s', 'e', 'v', 'e', 'n', ..] => '7',
            ['e', 'i', 'g', 'h', 't', ..] => '8',
            ['n', 'i', 'n', 'e', ..] => '9',
            _ => null,
        };
    }
}