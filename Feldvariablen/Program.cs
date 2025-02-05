int[] Temperatur =
{
    -1, 5, -4, -5, 12, -6, -5, -3, -3, 3, 2, 5, 8, -3, 10, 6, 10, 11, 1, -1,
    9, 3, 7, -7, 11, -5, 0, 5, 9, 13, -3, -5, 0
};

Console.Write("Aufgabe: ");
string input = Console.ReadLine();

if (input == "1")
{
    BerechneStatistik(Temperatur);
}
else if (input == "2")
{
    FindeExtremeTage(Temperatur);
}
else if (input == "3")
{
    ZeichneTemperaturenGraph(Temperatur);
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
    Console.WriteLine($"   Maximum: {highest}°C");
    Console.WriteLine($"   Minimum: {lowest}°C");
    Console.WriteLine($"Mittelwert:  {mid}°C");
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
    Console.WriteLine($"   Höchste Temperatur: {highest}°C am {DayNames(dayHighest)}   ({dayHighest + 1}.01.2025)");
    Console.WriteLine($"Niedrigste Temperatur: {lowest}°C am {DayNames(dayLowest)} ({dayLowest + 1}.01.2025)");
}

static void ZeichneTemperaturenGraph(int[] temperatur)
{
    Console.Clear();
    Console.WriteLine("                                          Temperaturverlauf (Januar 2025):");

    // Maximalwert der Temperaturen, um die Skala zu definieren (hier 15 Grad als Beispiel)
    int maxTemperatur = 15;
    int minTemperatur = -10;

    // Berechnen der vertikalen Achse (von max bis min Temperatur)
    for (int y = maxTemperatur; y >= minTemperatur; y--)
    {
        // Ausgabe der Temperaturachse
        Console.Write($"{y,3}°C | ");
        // Zeichne für jeden Tag die Balken
        for (int i = 0; i < temperatur.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (temperatur[i] >= y)
            {
                Console.Write("█  ");  // Zeichne Balken, wenn die Temperatur größer oder gleich dem aktuellen Wert ist
            }
            else
            {
                Console.Write("   ");  // Andernfalls nichts zeichnen
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Zeilenumbruch nach jeder Temperaturreihe
        Console.WriteLine();
    }
    Console.WriteLine("       --------------------------------------------------------------------------------------------------");
    Console.WriteLine("        M  D  M  D  F  S  S  M  D  M  D  F  S  S  M  D  M  D  F  S  S  M  D  M  D  F  S  S  M  D  M  D  F");
    Console.WriteLine("        O  I  I  O  R  A  O  O  I  I  O  R  A  O  O  I  I  O  R  A  O  O  I  I  O  R  A  O  O  I  I  O  R");
    Console.WriteLine("        N  E  T  N  E  M  N  N  E  T  N  E  M  N  N  E  T  N  E  M  N  N  E  T  N  E  M  N  N  E  T  N  E");
    Console.WriteLine("        T  N  T  N  I  S  N  T  N  T  N  I  S  N  T  N  T  N  I  S  N  T  N  T  N  I  S  N  T  N  T  N  I");
    Console.WriteLine("        A  S  W  E  T  T  T  A  S  W  E  T  T  T  A  S  W  E  T  T  T  A  S  W  E  T  T  T  A  S  W  E  T");
    Console.WriteLine("        G  T  O  R  A  A  A  G  T  O  R  A  A  A  G  T  O  R  A  A  A  G  T  O  R  A  A  A  G  T  O  R  A");
    Console.WriteLine("           A  C  S  G  G  G     A  C  S  G  G  G     A  C  S  G  G  G     A  C  S  G  G  G     A  C  S  G");
    Console.WriteLine("           G  H  T              G  H  T              G  H  T              G  H  T              G  H  T   ");
    Console.WriteLine("                 A                    A                    A                    A                    A   ");
    Console.WriteLine("                 G                    G                    G                    G                    G   ");
}

static string DayNames(int day)
{
    string[] tage = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
    return tage[(day-1) % 7];
}
