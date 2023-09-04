namespace AthleticsCompetitionApp
{
    public class AthleteInFile : AthleteInMemory
    {
        public delegate void AthleteResultsSavedToFileDelegate(object sender, EventArgs args);
        public  event AthleteResultsSavedToFileDelegate AthleteResultsSavedToFile;

        private const string fileName = "athletes_results.txt";
        public AthleteInFile(string name, string surname) : base(name, surname) { }

        public void SaveAthletesScoreboardToFile(List<AthleteInFile> athletes, string date, string place)
        {
            var index = 1;
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine("");
                writer.WriteLine($"Wyniki Zawodów lekkoatletycznych - {place}, {date}");
                writer.WriteLine("-------------------------------");
                foreach (var athlete in athletes)
                {
                    writer.WriteLine($"Miejsce {index}: {athlete.Name} {athlete.Surname} - {athlete.GetAthleteResults().Score:f2} pkt, wygrane konkurencje - {athlete.GetAthleteResults().EventsWon}");
                    writer.WriteLine($"[ Bieg na 100m - {athlete.GetAthleteResults().Athlete100mRunResult}s | Skok w dal - {athlete.GetAthleteResults().AthleteLongJumpResult}m | Pchnięcie kulą - {athlete.GetAthleteResults().AthleteShotPutResult}m ]");
                    writer.WriteLine("-------------------------------");
                    index++;
                }
                ShotEventSaveAthleteResultsToFile();
            }
        }

        public void ReadAthletesScoreboardFromFile()
        {
            if (File.Exists(fileName))
            {
                var reader = File.ReadAllText(fileName);
                Console.WriteLine(reader);
            }
            else
            {
                Console.WriteLine("Brak pliku do odczytania");
            }
        }

        private void ShotEventSaveAthleteResultsToFile()
        {
            if (AthleteResultsSavedToFile != null)
            {
                AthleteResultsSavedToFile(this, new EventArgs());
            }
        }
    }
}

