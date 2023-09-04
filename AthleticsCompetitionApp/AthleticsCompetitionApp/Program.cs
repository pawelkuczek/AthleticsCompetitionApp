using AthleticsCompetitionApp;

var competition = new Competition();
var date = "";
var place = "";
var name = "";
var surname = "";
Console.WriteLine("Zawody lekkoatletyczne");
Console.WriteLine("------------------------");
Console.WriteLine("Dodaj zawodników uczestniczących w zawodach oraz ich wyniki w: biegu na 100m, skoku w dal i pchnięciu kulą. Program policzy punkty zawodników oraz ułoży ich w zależnosci od zajmowanego miejsca. Ponadto progam zapisze do pliku tablicę wyników zawodów.");
Console.WriteLine("------------------------");
Console.WriteLine("Wpisanie w dowolnym momencie komendy q lub Q spowoduje zakończenie programu");

List<AthleteInFile> athletes = new List<AthleteInFile>();

while (true)
{
    try
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj datę zawodów np. 06.08.2023");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            goto LoopEnd;
        }
        competition.CheckIfDateIsCorrect(input);
        date = input;
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}


while (true)
{
    try
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj miejscowość odbywania się zawodów np. Wrocław");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            goto LoopEnd;
        }
        competition.CheckIFValueContainsOnlyLetters(input);
        place = input;
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

Start:
while (true)
{
    try
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj imię nowego zawodnika: ");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            goto LoopEnd;
        }
        competition.CheckIFValueContainsOnlyLetters(input);
        name = input;
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

while (true)
{
    try
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj nazwisko nowego zawodnika: ");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            goto LoopEnd;
        }
        competition.CheckIFValueContainsOnlyLetters(input);
        surname = input;
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

var athlete = new AthleteInFile(name, surname);
athlete.AthleteResultsSavedToFile += AthletesResultsSavedToFile;


while (true)
{
    try
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj wynik zawodnika w biegu na 100m, np. 10,97 (akceptowany przedział: 9,4 - 20): ");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            goto LoopEnd;
        }
        athlete.Add100meterRunResult(input);
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

while (true)
{
    try
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj wynik zawodnika w skoku w dal np. 7,79 (akceptowany przedział: 2 - 9,5): ");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            goto LoopEnd;
        }
        athlete.AddLongJumpResult(input);
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

while (true)
{
    try
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Podaj wynik zawodnika w pchnięciu kulą np. 21,51 (akceptowany przedział: 6 - 24,5): ");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            goto LoopEnd;
        }
        athlete.AddShotPutResult(input);
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
athletes.Add(athlete);
athlete.NewAthleteCreated += NewAthleteCreated;
athlete.NewAthleteCreatedMessage();


Console.WriteLine("Czy chcesz stworzyć nowego zawodnika? T - tak, N - nie (wyjście z programu)");
LastInput:
var inputEnd = Console.ReadLine();

switch (inputEnd)
{
    case "T":
    case "t":
        goto Start;
    case "N":
    case "n":
        competition.Check100mRunWinner(athletes);
        competition.CheckLongJumpWinner(athletes);
        competition.CheckShotPutWinner(athletes);
        competition.SortAthletesByScore(athletes);
        athlete.SaveAthletesScoreboardToFile(athletes, date, place);
        athlete.ReadAthletesScoreboardFromFile();
        goto LoopEnd;
    default:
        Console.WriteLine("Nieprawidłowa wartość. Wpisz: T - aby stworzyć nowego zawodnika, N - nie twórz zawodnika i wyjdź ");
        goto LastInput;
}
LoopEnd:
Console.WriteLine("ZAKOŃCZONO DZIAŁANIE PROGRAMU");

void NewAthleteCreated(object sender, EventArgs args)
{
    Console.WriteLine("STWORZONO NOWEGO ZAWODNIKA");
}

void AthletesResultsSavedToFile(object sender, EventArgs args)
{
    Console.WriteLine("ZAPISANO WYNIKI ZAWODNIKÓW DO PLIKU");
}

////WERSJA BEZ ZAPISYWANIA DO PLIKU PRZY UŻYCIU ATHLETE IN MEMORY
//var competition = new Competition();
//var date = "";
//var place = "";
//var name = "";
//var surname = "";
//Console.WriteLine("Zawody lekkoatletyczne");
//Console.WriteLine("------------------------");
//Console.WriteLine("Dodaj zawodników uczestniczących w zawodach oraz ich wyniki w: biegu na 100m, skoku w dal i pchnięciu kulą. Program policzy punkty zawodników oraz ułoży ich w zależnosci od zajmowanego miejsca.");
//Console.WriteLine("------------------------");
//Console.WriteLine("Wpisanie w dowolnym momencie komendy q lub Q spowoduje zakończenie programu");

//List<AthleteInMemory> athletes = new List<AthleteInMemory>();

//while (true)
//{
//    try
//    {
//        Console.WriteLine("------------------------");
//        Console.WriteLine("Podaj datę zawodów np. 06.08.2023");
//        var input = Console.ReadLine();
//        if (input == "q" || input == "Q")
//        {
//            goto LoopEnd;
//        }
//        competition.CheckIfDateIsCorrect(input);
//        date = input;
//        break;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}


//while (true)
//{
//    try
//    {
//        Console.WriteLine("------------------------");
//        Console.WriteLine("Podaj miejscowość odbywania się zawodów np. Wrocław");
//        var input = Console.ReadLine();
//        if (input == "q" || input == "Q")
//        {
//            goto LoopEnd;
//        }
//        competition.CheckIFValueContainsOnlyLetters(input);
//        place = input;
//        break;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//Start:
//while (true)
//{
//    try
//    {
//        Console.WriteLine("------------------------");
//        Console.WriteLine("Podaj imię nowego zawodnika: ");
//        var input = Console.ReadLine();
//        if (input == "q" || input == "Q")
//        {
//            goto LoopEnd;
//        }
//        competition.CheckIFValueContainsOnlyLetters(input);
//        name = input;
//        break;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//while (true)
//{
//    try
//    {
//        Console.WriteLine("------------------------");
//        Console.WriteLine("Podaj nazwisko nowego zawodnika: ");
//        var input = Console.ReadLine();
//        if (input == "q" || input == "Q")
//        {
//            goto LoopEnd;
//        }
//        competition.CheckIFValueContainsOnlyLetters(input);
//        surname = input;
//        break;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//var athlete = new AthleteInMemory(name, surname);

//while (true)
//{
//    try
//    {
//        Console.WriteLine("------------------------");
//        Console.WriteLine("Podaj wynik zawodnika w biegu na 100m, np. 10,97 (akceptowany przedział: 9,4 - 20): ");
//        var input = Console.ReadLine();
//        if (input == "q" || input == "Q")
//        {
//            goto LoopEnd;
//        }
//        athlete.Add100meterRunResult(input);
//        break;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//while (true)
//{
//    try
//    {
//        Console.WriteLine("------------------------");
//        Console.WriteLine("Podaj wynik zawodnika w skoku w dal np. 7,79 (akceptowany przedział: 2 - 9,5): ");
//        var input = Console.ReadLine();
//        if (input == "q" || input == "Q")
//        {
//            goto LoopEnd;
//        }
//        athlete.AddLongJumpResult(input);
//        break;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//while (true)
//{
//    try
//    {
//        Console.WriteLine("------------------------");
//        Console.WriteLine("Podaj wynik zawodnika w pchnięciu kulą np. 21,51 (akceptowany przedział: 6 - 24,5): ");
//        var input = Console.ReadLine();
//        if (input == "q" || input == "Q")
//        {
//            goto LoopEnd;
//        }
//        athlete.AddShotPutResult(input);
//        break;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//athletes.Add(athlete);
//athlete.NewAthleteCreated += NewAthleteCreated;
//athlete.NewAthleteCreatedMessage();


//Console.WriteLine("Czy chcesz stworzyć nowego zawodnika? T - tak, N - nie (wyjście z programu)");
//LastInput:
//var inputEnd = Console.ReadLine();

//switch (inputEnd)
//{
//    case "T":
//    case "t":
//        goto Start;
//    case "N":
//    case "n":
//        competition.Check100mRunWinner(athletes);
//        competition.CheckLongJumpWinner(athletes);
//        competition.CheckShotPutWinner(athletes);
//        competition.SortAthletesByScore(athletes);
//        athlete.ShowAthletesScoreboardFromMemory(athletes, date, place);
//        goto LoopEnd;
//    default:
//        Console.WriteLine("Nieprawidłowa wartość. Wpisz: T - aby stworzyć nowego zawodnika, N - nie twórz zawodnika i wyjdź ");
//        goto LastInput;
//}
//LoopEnd:
//Console.WriteLine("ZAKOŃCZONO DZIAŁANIE PROGRAMU");

//void NewAthleteCreated(object sender, EventArgs args)
//{
//    Console.WriteLine("STWORZONO NOWEGO ZAWODNIKA");
//}
