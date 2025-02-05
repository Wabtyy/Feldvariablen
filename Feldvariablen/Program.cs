int[] Temperatur = 
{
    -1, 5, -4, -5, 12, -6, -5, -3, -3, 3, 2, 5, 8, -3, 10, 6, 10, 11, 1, -1,
    9, 3, 7, -7, 11, -5, 0, 5, 9, 13, -3, -5, 0, -3, 3, 8, 3, -4, 12, 12,
    6, -5, 1, 10, -3, -5, 13, -6, 8, 8, -4, -4, 5, 8, -3, 0
};

Console.Write("Aufgabe: ");
string input = Console.ReadLine();

if (input == "1")
{
    BerechneStatistik(Temperatur);
}
else
{
    FindeExtremeTage(Temperatur);
}

static void BerechneStatistik(int[] temperatur)
{
    int highest = temperatur[0];
    int lowest = temperatur[0];
    int sum = 0;

    foreach (int temp in temperatur)
    {
        if (highest < temp) highest = temp;
        if (lowest > temp) lowest = temp;
        sum += temp;
    }

    int mid = sum / temperatur.Length;

    Console.Clear();
    Console.WriteLine($"   Maximum: {highest}");
    Console.WriteLine($"   Minimum: {lowest}");
    Console.WriteLine($"Mittelwert:  {mid}");
}

static void FindeExtremeTage(int[] temperatur)
{
    int highest = temperatur[0];
    int lowest = temperatur[0];
    int dayHighest = 0;
    int dayLowest = 0;

    for (int i = 0; i < temperatur.Length; i++)
    {
        if (highest < temperatur[i])
        {
            highest = temperatur[i];
            dayHighest = i;
        }

        if (lowest > temperatur[i])
        {
            lowest = temperatur[i];
            dayLowest = i;
        }
    }

    Console.Clear();
    Console.WriteLine($"   Höchste Temperatur: {highest}°C am {DayNames(dayHighest)}   ({dayHighest}.01.2025)");
    Console.WriteLine($"Niedrigste Temperatur: {lowest}°C am {DayNames(dayLowest)} ({dayLowest}.01.2025)");
}

static string DayNames(int day)
{
    string[] tage = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
    return tage[(day-1 )% 7];
}
