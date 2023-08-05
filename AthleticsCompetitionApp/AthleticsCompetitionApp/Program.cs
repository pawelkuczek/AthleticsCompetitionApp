using AthleticsCompetitionApp;

Console.WriteLine("Test programu Zawody Lekkoatletyczne");
var athlete = new AthleteInFile("Usain", "Bolt");

athlete.Add100meterRunResult(9.88);
athlete.AddLongJumpResult(8.92);
athlete.AddShotPutResult(22.55);

athlete.SaveAthleteResultsToFile();

using (var reader = File.OpenText("athletes_results.txt"))
{
    var lines = reader.ReadToEnd();
    Console.WriteLine(lines);
}