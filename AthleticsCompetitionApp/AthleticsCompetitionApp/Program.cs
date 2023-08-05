using AthleticsCompetitionApp;


Console.WriteLine("Test programu Zawody Lekkoatletyczne");
var athlete = new AthleteInFile("Usain", "Bolt");
athlete.Athlete100mRunResultAdded += Athlete100mRunResultAdded;
athlete.AthleteLongJumpResultAdded += AthleteLongJumpResultAdded;
athlete.AthleteShotPutResultAdded += AthleteShotPutResultAdded;
athlete.AthleteResultsSavedToFile += AthleteResultsSavedToFile;
athlete.Add100meterRunResult(9.88);
athlete.AddLongJumpResult(8.92);
athlete.AddShotPutResult(22.55);
athlete.SaveAthleteResultsToFile();
void Athlete100mRunResultAdded (object sender, EventArgs args)
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


