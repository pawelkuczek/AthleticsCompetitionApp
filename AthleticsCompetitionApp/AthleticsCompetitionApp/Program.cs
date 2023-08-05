using AthleticsCompetitionApp;

Console.WriteLine("Zawody lekkoatletyczne");
Console.WriteLine("------------------------");
Console.WriteLine("Program służy do dodawania zawodników uczestniczących w zawodach oraz ich wyników w trzech konkurencjach: biegu na 100m, skoku w dal i pchnięciu kulą. Program policzy punkty zawodników oraz ułoży ich w zależnosci od zajmowanego miejsca.");
Console.WriteLine("------------------------");
Console.WriteLine("Wpisanie w każdym momencie komendy q lub Q spowoduje zakończenie programu");
Console.WriteLine("Jeśli nie chcesz dodawać więcej zawodników, to po komunikacie: 'Zapisano wyniki zawodnika do pliku' również wpisz do konsoli q lub Q aby wyjść.");

List<AthleteInMemory> athletes = new List<AthleteInMemory>();

while (true)
{
    Console.WriteLine("------------------------");
    Console.WriteLine("Podaj imię zawodnika: ");
    var inputName = Console.ReadLine();
    if (inputName == "q" || inputName == "Q")
    {
        goto LoopEnd;
    }
    Console.WriteLine("------------------------");
    Console.WriteLine("Podaj nazwisko zawodnika: ");
    var inputSurname = Console.ReadLine();
    if (inputSurname == "q" || inputSurname == "Q")
    {
        goto LoopEnd;
    }

    var athlete = new AthleteInFile(inputName, inputSurname);
    athlete.Athlete100mRunResultAdded += Athlete100mRunResultAdded;
    athlete.AthleteLongJumpResultAdded += AthleteLongJumpResultAdded;
    athlete.AthleteShotPutResultAdded += AthleteShotPutResultAdded;
    athlete.AthleteResultsSavedToFile += AthleteResultsSavedToFile;


    while (true)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj wynik zawodnika w biegu na 100m (np. 10,97): ");
        var input100mRunResult = Console.ReadLine();

        try
        {
            if (input100mRunResult == "q" || input100mRunResult == "Q")
            {
                goto LoopEnd;
            }
            athlete.Add100meterRunResult(input100mRunResult);
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }

    while (true)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj wynik zawodnika w skoku w dal (np. 7,79): ");
        var inputLongJumpnResult = Console.ReadLine();

        try
        {
            if (inputLongJumpnResult == "q" || inputLongJumpnResult == "Q")
            {
                goto LoopEnd;
            }
            athlete.AddLongJumpResult(inputLongJumpnResult);
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }

    while (true)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj wynik zawodnika w pchnięciu kulą (np. 21,51): ");
        var inputShotPutResult = Console.ReadLine();
        if (inputShotPutResult == "q" || inputShotPutResult == "Q")
        {
            goto LoopEnd;
        }
        try
        {
            athlete.AddShotPutResult(inputShotPutResult);
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }

    athlete.SaveAthleteResultsToFile();
    athletes.Add(athlete);

}

LoopEnd:
if (athletes.Count > 0)
{
    Console.WriteLine("Zakończono dodawanie zawodników.");
}
else
{
    Console.WriteLine("Zakończono działanie programu.");
}


if (athletes.Count > 0)
{


    athletes.Sort((a1, a2) => a1.GetAthleteResults().Score.CompareTo(a2.GetAthleteResults().Score));
    athletes.Reverse();
    var index = 1;
    Console.WriteLine("Wyniki Zawodów lekkoatletycznych");
    Console.WriteLine("-------------------------------");


    {
        foreach (var athlete in athletes)
        {
            Console.WriteLine($"{index}. {athlete.Name} {athlete.Surname} - {athlete.GetAthleteResults().Score} pkt");
            Console.WriteLine("-------------------------------");
            index++;
        }
    }

}
void Athlete100mRunResultAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano wynik zawodnika na 100m");
}

void AthleteLongJumpResultAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano wynik zawodnika w skoku w dal");
}

void AthleteShotPutResultAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano wynik zawodnika w pchnięciu kulą");
}

void AthleteResultsSavedToFile(object sender, EventArgs args)
{
    Console.WriteLine("Zapisano wyniki zawodnika do pliku");
}


