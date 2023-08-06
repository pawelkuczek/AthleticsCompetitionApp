namespace AthleticsCompetitionApp
{
    public class AthleteInFile : AthleteInMemory
    {
        private const string fileName = "athletes_results.txt";
        public AthleteInFile(string name, string surname) : base(name, surname) { }

        public void SaveAthleteResultsToFile()
        {

            var athleteResults = this.GetAthleteResults();

            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine($"Wyniki zawodnika: {this.Name} {this.Surname}");
                writer.WriteLine($"Bieg na 100m: {athleteResults.Athlete100mRunResult}s");
                writer.WriteLine($"Skok w dal: {athleteResults.AthleteLongJumpResult}m");
                writer.WriteLine($"Pchnięcie kulą: {athleteResults.AthleteShotPutResult}m");
                writer.WriteLine($"Ilość punktów: {athleteResults.Score} pkt");
                writer.WriteLine("---------------------");

            }
            this.ShotEventSaveAthleteResultsToFile();
        }


       public static void SaveAthletesScoreboardToFile(List<AthleteInFile> athletes)
        {
            //athletes.Sort((a1, a2) => a1.GetAthleteResults().Athlete100mRunResult.CompareTo(a2.GetAthleteResults().Athlete100mRunResult));
            //athletes[0].GetAthleteResults().EventsWon += 1;
            //athletes.Sort((a1, a2) => a1.GetAthleteResults().AthleteLongJumpResult.CompareTo(a2.GetAthleteResults().AthleteLongJumpResult));
            //athletes.Reverse();
            //athletes[0].GetAthleteResults().EventsWon += 1;
            //athletes.Sort((a1, a2) => a1.GetAthleteResults().AthleteShotPutResult.CompareTo(a2.GetAthleteResults().AthleteShotPutResult));
            //athletes.Reverse();
            //athletes[0].GetAthleteResults().EventsWon += 1;

            //foreach (var athlete in athletes)
            //{
            //    athlete.GetAthleteResults().EventsWon += athlete.GetAthleteResults().Score;
            //}
            athletes.Sort((a1, a2) => a1.GetAthleteResults().Score.CompareTo(a2.GetAthleteResults().Score));
            athletes.Reverse();
            var index = 1;
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine("Wyniki Zawodów lekkoatletycznych");
                Console.WriteLine("-------------------------------");
                foreach (var athlete in athletes)
                {
                    writer.WriteLine($"Miejsce {index}: {athlete.Name} {athlete.Surname} - {athlete.GetAthleteResults().Score} pkt, wygrane konkurencje - {athlete.GetAthleteResults().EventsWon}");
                    writer.WriteLine($"[ Bieg na 100m - {athlete.GetAthleteResults().Athlete100mRunResult}s, Skok w dal - {athlete.GetAthleteResults().AthleteLongJumpResult}m, Pchnięcie kulą - {athlete.GetAthleteResults().AthleteShotPutResult}m]");
                    writer.WriteLine("-------------------------------");
                    index++;
                }
            }
        }
    }
}

