namespace AthleticsCompetitionApp
{
    public class AthleteInFile : AthleteInMemory
    {
        private const string fileName = "athletes_results.txt";
        public AthleteInFile(string name, string surname) : base(name, surname) { }
    
      public void SaveAthleteResultsToFile() { 

            var athleteResults = this.GetAthleteResults();

            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine($"Wyniki zawodnika: {this.Name} {this.Surname}");
                writer.WriteLine($"Bieg na 100m: {athleteResults.Athlete100mRunResult}s");
                writer.WriteLine($"Skok w dal: {athleteResults.AthleteLongJumpResult}m");
                writer.WriteLine($"Pchnięcie kulą: {athleteResults.AthleteShotPutResult}m");
                writer.WriteLine($"Ilość punktów: {athleteResults.Score} pkt");
                writer.WriteLine($"Klasa zawodnika: {athleteResults.AthleteClassification}");
                writer.WriteLine("---------------------");

            }
            this.ShotEventSaveAthleteResultsToFile();
        } 
    }
}
